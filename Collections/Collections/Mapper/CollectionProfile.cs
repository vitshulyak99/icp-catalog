using AutoMapper;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Services.Dto;

namespace Collections.Mapper
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDto>()
                .ForMember(d => d.Owner, opt => opt.MapFrom(d => d.Owner));
            CreateMap<CollectionDto, Collection>()
                .ForMember(d => d.Owner, opt => opt.MapFrom(s => new AppUser 
                {
                    Id = s.Owner.Id
                }))
                .ForMember(d => d.SearchVector, opt => opt.Ignore())
                .ForMember(x => x.Items, x => x.Ignore());
        }
    }
}