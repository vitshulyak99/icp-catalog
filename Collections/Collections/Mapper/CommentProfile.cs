using AutoMapper;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Services.Dto;

namespace Collections.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(d=>d.Sender,opt=>opt.MapFrom(s=>s.Sender))
                .ForMember(d=>d.ItemId, opt=> opt.MapFrom(s=>s.Item.Id));
            CreateMap<CommentDto, Comment>()
                .ForMember(d=>d.Sender,opt=>opt.MapFrom(s=> new AppUser
                {
                    Id = s.Sender.Id
                }))
                .ForMember(dest => dest.SearchVector, opt => opt.Ignore())
                .ForMember(dest => dest.Item, opt => opt.MapFrom(s => new Item {Id = s.ItemId}));
        }
    }
}