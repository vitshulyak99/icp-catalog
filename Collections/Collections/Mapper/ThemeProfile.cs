using AutoMapper;
using Collections.DAL.Entities;
using Services.Dto;

namespace Collections.Mapper
{
    public class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<Theme, ThemeDto>();
            CreateMap<ThemeDto, Theme>()
                .ForMember(dest => dest.Collections, opt => opt.Ignore());
        }
    }
}