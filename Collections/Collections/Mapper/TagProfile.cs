using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models.Item;

namespace Collections.Mapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagModel>()
                .ForMember(x=>x.Count, x=>x.MapFrom(c=>c.ItemTags.Count));
        }
    }
}