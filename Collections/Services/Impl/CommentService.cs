using System.Linq;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;
using Services.DTO;

namespace Services.Impl
{
    public class CommentService : BaseCrudService<Comment,CommentDto>, ICommentService
    {
        public CommentService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Comment> Include(IQueryable<Comment> query) => 
            query.Include(x => x.Item).Include(x => x.Sender);

        public override CommentDto Create(CommentDto dto)
        {
            var entity = Mapper.Map<Comment>(dto);
            if (entity.Item is not null)
            {
                Context.Attach(entity.Item);
            }

            if (entity.Sender is not null)
            {
                Context.Attach(entity.Sender);
            }

            return base.Create(dto);
        }
    }
}