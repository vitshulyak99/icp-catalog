using AutoMapper;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Services.DTO;

namespace Collections.Mapper
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDto>()
                .ForMember(d => d.OwnerId, opt => opt.MapFrom(s => s.Owner.Id));
            CreateMap<CollectionDto, Collection>()
                .ForMember(d => d.SearchVector, opt => opt.Ignore())
                .ForMember(d => d.Owner, opt => opt.MapFrom(s => new AppUser { Id = s.OwnerId }))
                .ForMember(x => x.Items, x => x.Ignore());
        }
    }
}