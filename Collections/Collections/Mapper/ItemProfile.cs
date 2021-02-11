using System.Linq;
using AutoMapper;
using Collections.DAL.Entities;
using Services.Dto;

namespace Collections.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(d => d.Likes, opt => opt.MapFrom(s => s.Likes.Select(c => c.UserId)))
                .ForMember(d => d.CollectionId, opt => opt.MapFrom(s => s.Collection.Id));
            CreateMap<ItemDto,Item>()
                .ForMember(d=>d.Collection,opt=>opt.MapFrom(s=> new Collection{ Id = s.CollectionId}))
                .ForMember(x=>x.SearchVector, opt=>opt.Ignore())
                .ForMember(x=>x.Likes, opt=>opt.Ignore())
                .ForMember(x=>x.Comments, opt=>opt.Ignore());
        }
    }
}