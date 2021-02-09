using AutoMapper;
using Collections.DAL.Entities;
using Services.DTO;

namespace Collections.Mapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>()
                .ForMember(d=>d.ItemTags,opt=>opt.Ignore());
        }
    }
}