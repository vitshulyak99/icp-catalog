using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models;

namespace Collections.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Theme, ThemeModel>();
            CreateMap<ThemeModel, Theme>()
                .ForMember(x=>x.Collections,x=>x.Ignore());
        }
    }
}