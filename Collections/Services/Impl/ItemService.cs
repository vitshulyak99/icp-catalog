using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.General;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;
using Services.DTO;

namespace Services.Impl
{
    public class ItemService : BaseCrudService<Item,ItemDto>, IItemService
    {
        public ItemService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            Users = context.Set<AppUserRole>();
            Likes = context.Likes;
        }

        private DbSet<AppUserRole> Users { get; }
        private DbSet<Like> Likes { get; }

        public bool HasPermissions(int id, int userId) =>
            Set.Where(x => x.Id.Equals(id))
               .Any(x => x.Collection.Owner.Id.Equals(userId)) || Users
                .Where(x => x.Role.Name.Equals(Constants.Roles.Admin))
                .Any(x => x.UserId.Equals(userId));
        
        protected override IQueryable<Item> Include(IQueryable<Item> query)
        {
            return query.Include(x => x.Collection)
                        .Include(x => x.Comments)
                        .Include(x => x.Fields)
                        .Include(x => x.Tags)
                        .Include(x => x.Likes);
        }

        public bool SetLike(int id, int userId)
        {
            Expression<Func<Like,bool>> expression = x => x.ItemId.Equals(id) && x.UserId.Equals(userId);
            var isExist = Likes.Any(expression);

            if (isExist)
            {
                Likes.Remove(Likes.First(x => x.ItemId.Equals(id) && x.UserId.Equals(userId)));
            }
            else
            {
                Likes.Add(new Like {UserId = userId, ItemId = id});
            }

            Context.SaveChanges();
            return !isExist;
        }

        public IEnumerable<ItemDto> Search(string text)
        {
            var items = 
                Set.Where(x => x.SearchVector.Matches(text)
                               || x.Collection.SearchVector.Matches(text)
                               || x.Fields.Any(c => c.SearchVector.Matches(text))
                               || x.Comments.Any(c => c.SearchVector.Matches(text)));
            return ProjectTo(Include(items)).ToList();
        }

        public IEnumerable<ItemDto> GetByCollection(int id) => 
            ProjectTo(Include(Set.Where(x => x.Collection.Id.Equals(id)))).ToList();

        public IEnumerable<ItemDto> GetByTag(int id) => 
            ProjectTo(Include(Set.Where(x => x.Tags.Any(c => c.Id.Equals(id))))).ToList();

        public override ItemDto Create(ItemDto dto)
        {
            var item = Mapper.Map<Item>(dto);

            Context.Attach(item.Collection);
            item.Fields.ForEach(x => Context.Attach(x.Field));
            item.Tags.ForEach(x =>
            {
                if (x.Id is not 0)
                {
                    Context.Attach(x);
                }
            });
            item = BaseCreate(item);
            return Mapper.Map<ItemDto>(item);
        }
    }
}