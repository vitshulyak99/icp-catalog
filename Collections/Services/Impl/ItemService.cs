using System.Collections.Generic;
using System.Linq;
using Collections.DAL;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.DAL.Expressions;
using Collections.General;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class ItemService : BaseCrudService<Item>, IItemService
    {
        public ItemService(AppDbContext context) : base(context)
        {
            FieldValues = context.FieldValues;
            Collections = context.Collections;
            Comments = context.Comments;
        }
        protected DbSet<FieldValue> FieldValues { get; }
        protected DbSet<Collection> Collections { get; }
        protected DbSet<Comment> Comments { get; }
        protected DbSet<AppUser> Users { get; }

        public bool SetLike(int id, int userId)
        {
            var item = Set.Where(x => x.Id.Equals(id)).Include(x => x.UserLike).FirstOrDefault();
            var user = Context.Set<AppUser>().FirstOrDefault(x => x.Id.Equals(userId));
            if (item is null || user is null) return false;
            var isLiked = item.UserLike.Contains(user);
            if (isLiked)
            {
                item.UserLike.Remove(user);
            }
            else
            {
                item.UserLike.Add(user);
            }
            Set.Update(item);
            Context.SaveChanges();
            return isLiked;
        }

        public IQueryable<Item> Search(string text)
        {
            var q1 = Set.FullText(text);
            var q2 = FieldValues.FullText(text).Select(x => x.Item);
            var q3 = Collections.FullText(text).SelectMany(x => x.Items);
            var q4 = Comments.FullText(text).Select(x => x.Item);
            return q1.Union(q2)
                     .Union(q3)
                     .Union(q4)
                     .Include(x => x.Fields)
                     .Include(x => x.Tags)
                     .Include(x => x.UserLike)
                     .Include(x => x.Comments)
                     .Include(x => x.Collection).ThenInclude(x=>x.Fields);

        }

        public IEnumerable<Item> GetByCollection(int id) =>
            Collections
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .SelectMany(x => x.Items)
                .Include(x => x.Fields)
                .Include(x => x.UserLike)
                .Include(x => x.Tags).ToArray();

        public override Item Create(Item entity)
        {
            Set.Add(entity);
            Context.Attach(entity.Collection);
            entity.Tags.ForEach(x =>
            {
                if (x.Id > 0) Context.Attach(x);
            });
            entity.Fields.ForEach(x =>
            {
                Context.Attach(x.Field);
            });
            return base.Create(entity);
        }

        public override Item GetById(int id) =>
            Set.Where(x => x.Id.Equals(id))
               .Include(x => x.Fields).ThenInclude(x => x.Field)
               .Include(x => x.Tags)
               .Include(x => x.UserLike)
               .FirstOrDefault();

        public override Item Update(Item entity)
        {
            entity.Fields.ForEach(x =>
            {
                Context.Attach(x);
                Context.Update(x);
            });
            Context.Attach(entity);
            Context.Update(entity);
            Context.SaveChanges();

            return base.Update(entity);
        }

        public bool HasPermissions(int id, int userid) =>
            Set.Where(x => x.Id.Equals(id)).Select(x => x.Collection.Owner)
               .Union(Users.Where(x => x.UserRoles.Exists(x => x.Role.Name.Equals(Constants.Roles.Admin))))
               .Any(x => x.Id.Equals(userid));
    }

    
}