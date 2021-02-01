using System.Collections.Generic;
using System.Linq;
using Collections.DAL;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.General;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class CollectionService : BaseCrudService<Collection>, ICollectionService
    {
        public CollectionService(AppDbContext context) : base(context)
        {
            this.Users = context.Users;
        }

        public DbSet<AppUser> Users { get; set; }

        public override Collection Create(Collection entity)
        {
            if (entity.Owner == null) return base.Create(entity);
            Context.Attach(entity.Owner);
            Context.Attach(entity.Theme);
            return base.Create(entity);
        }

        public bool HasPermissions(int id, int userId) =>
            Set.Where(x => x.Id.Equals(id))
                       .Select(x => x.Owner)
                       .Union(Context.Set<AppUserRole>()
                                     .Where(x => x.Role.Name.Equals(Constants.Roles.Admin))
                                     .Select(x => x.User))
                       .Any(x => x.Id.Equals(userId));

        public IEnumerable<Field> GetFields(int collectionId) =>
            Set.Where(x => x.Id.Equals(collectionId))
               .SelectMany(x => x.Fields)
               .ToArray();

        public IEnumerable<Collection> ByUser(int userId)
            => Set.Where(x => x.Owner.Id.Equals(userId))
                  .Include(x => x.Theme)
                  .Include(x => x.Owner)
                  .Include(x => x.Fields);

        public override IQueryable<Collection> Get() => 
            Set.Include(x => x.Theme)
               .Include(x=>x.Owner)
               .Include(x=>x.Fields);

        public override Collection GetById(int id) => Get().Where(x=>x.Id.Equals(id)).Include(x=>x.Fields).FirstOrDefault();

        public override Collection Update(Collection entity)
        {
            var old = Set.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (old is null) return null;
            Context.Attach(entity.Theme);
            old.Theme = entity.Theme;
            old.Title = entity.Title;
            old.Description = entity.Description;
            old.Image = entity.Image;
            return Set.Update(old).Entity;
        }
    }
}
