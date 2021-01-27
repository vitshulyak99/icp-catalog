using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Collections.General;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class CollectionService : BaseCrudService<Collection>, ICollectionService
    {
        public CollectionService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Collection Create(Collection entity)
        {
            if (entity.Owner == null) return base.Create(entity);
            entity.Owner = Context.Users.First(x => x.UserName == entity.Owner.UserName);
            Context.Attach(entity.Owner);

            return base.Create(entity);
        }

        public bool CheckPermissions(int id, string username) =>
            Context.Collections.Select(x => x.Owner).First(x => x.Id == id).UserName == username || username == Constants.Roles.Admin;

        public override Collection GetById(int id)
        {
            var collection = Set.Include(x => x.Owner)
                                .Include(x => x.Items)
                                .ThenInclude(x => x.Tags)
                                .Include(x => x.Items)
                                .ThenInclude(x => x.Fields)
                                .Include(x => x.Theme)
                                .FirstOrDefault(x => x.Id.Equals(id));

            return collection;
        }

        public override IEnumerable<Collection> Get()
        {
            return Set.Include(x => x.Theme);
        }
    }
}
