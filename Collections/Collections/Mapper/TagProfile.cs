using AutoMapper;
using Collections.DAL.Entities;
using Services.Dto;

namespace Collections.Mapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>()
                .ForMember(d=>d.Uses, opt=>opt.MapFrom(s=>s.ItemTags.Count));
            CreateMap<TagDto, Tag>()
                .ForMember(d=>d.ItemTags,opt=>opt.Ignore());
        }
        
    }
}