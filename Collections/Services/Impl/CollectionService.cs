using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class CollectionService : BaseCrudService<Collection, CollectionDto>, ICollectionService
    {
        protected DbSet<AppUserRole> UserRoles { get; }

        public CollectionService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            UserRoles = context.Set<AppUserRole>();
        }

        protected override IQueryable<Collection> Include(IQueryable<Collection> query) =>
            query.Include(x => x.Owner)
                 .Include(x => x.Theme)
                 .Include(x => x.Fields);

        public virtual bool HasPermissions(int id, int userId) =>
            Set.Where(x => x.Id.Equals(id))
               .Any(x => x.Owner.Id.Equals(userId))
            || UserRoles.Where(x => x.UserId.Equals(userId))
                        .Any(x => x.Role.Name.Equals(Constants.Roles.Admin));

        public virtual IEnumerable<FieldDto> GetFields(int id) =>
            Set.Where(x => x.Id.Equals(id)).ProjectTo<CollectionDto>(Mapper.ConfigurationProvider)
               .SelectMany(x => x.Fields).ToList();

        public virtual IEnumerable<CollectionDto> ByUser(int userId) =>
            ProjectTo(Include(Set.Where(x => x.Owner.Id.Equals(userId)))).ToList();

        public override CollectionDto Create(CollectionDto dto)
        {
            var collection = Mapper.Map<Collection>(dto);
            Context.Attach(collection.Theme);
            Context.Attach(collection.Owner);
            collection = BaseCreate(collection);
            return Mapper.Map<CollectionDto>(collection);
        }
    }
}