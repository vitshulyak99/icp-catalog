using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models;
using Collections.Models.Comment;

namespace Collections.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Theme, ThemeModel>();
            CreateMap<ThemeModel, Theme>()
                .ForMember(x=>x.Collections,x=>x.Ignore());
            CreateMap<Comment, CommentViewModel>()
                .ForMember(x=>x.ItemId,x=>x.MapFrom(c=>c.Item.Id))
                .ForMember(x=>x.Item,x=>x.MapFrom(c=>c.Item));
            CreateMap<CommentModel, Comment>()
                .ForMember(x=>x.Item,x=>x.MapFrom(c=> new Item(){Id = c.ItemId }))
                .ForMember(x=>x.Sender, x=>x.Ignore())
                .ForMember(x=>x.Id,x=>x.Ignore());
        }
    }
}