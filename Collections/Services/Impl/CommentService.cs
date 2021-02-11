using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Collections.DAL;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Abstractions.Interfaces;
using Services.Dto;

namespace Services.Impl
{
    public class CommentService : BaseCrudService<Comment,CommentDto>, ICommentService
    {
        public CommentService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Comment> Include(IQueryable<Comment> query) => 
            query.Include(x => x.Sender);

        public override CommentDto Create(CommentDto dto)
        {
            var entity = Mapper.Map<Comment>(dto);
            if (entity.Item is not null && entity.Item.Id > 0)
            {
                Context.Attach(entity.Item);
            }

            if (entity.Sender is not null  && entity.Sender.Id > 0)
            {
                Context.Attach(entity.Sender);
            }

            return base.Create(dto);
        }

        public IEnumerable<CommentDto> GetByItem(int id)
        {
            var comments = ProjectTo(Include(Set.Where(x => x.Item.Id.Equals(id)))).ToList();
            return comments;
        }
    }
}