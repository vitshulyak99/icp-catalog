using System.Linq;
using Collections.DAL;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;

namespace Services.Impl
{
    public class CommentService :BaseCrudService<Comment>, ICommentService
    {
        public CommentService(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<Comment> Get()
        {
            return base.Get().Include(x=>x.Item).Include(x=>x.Sender);
        }

        public override Comment Create(Comment entity)
        {
            if (entity.Item is not null)
            {
                Context.Attach(entity.Item);
            }

            if (entity.Sender is not null)
            {
                Context.Attach(entity.Sender);
            }

            return base.Create(entity);
        }
    }
}