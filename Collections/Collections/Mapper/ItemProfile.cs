using System.Linq;
using AutoMapper;
using Collections.DAL.Entities;
using Services.DTO;

namespace Collections.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(d=>d.Likes,opt=>opt.MapFrom(s=>s.Likes.Select(c=>c.UserId)));
            CreateMap<ItemDto,Item>()
                .ForMember(x=>x.SearchVector, opt=>opt.Ignore())
                .ForMember(x=>x.Likes, opt=>opt.Ignore())
                .ForMember(x=>x.Comments, opt=>opt.Ignore());
        }
    }
}