using AutoMapper;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.Models.Collection;

namespace Collections.Mapper
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<CollectionModel, Collection>()
                .ForMember(x => x.Fields, x => x.Ignore())
                .ForMember(x => x.Owner, x => x.Ignore())
                .ForMember(x => x.Items, x => x.Ignore())
                .ForMember(x=>x.Id,x=>x.Ignore());
            CreateMap<CollectionCreateModel, Collection>()
                .IncludeBase<CollectionModel, Collection>()
                .ForMember(x => x.Fields, x => x.MapFrom(c => c.Fields))
                .ForMember(x => x.Owner, x => x.MapFrom(x => new AppUser(x.OwnerName)))
                .ForMember(x => x.Items, x => x.Ignore());

            CreateMap<CollectionSimpleModel, Collection>()
                .IncludeBase<CollectionModel, Collection>()
                .ForMember(x => x.Fields, x => x.Ignore())
                .ForMember(x => x.Items, x => x.Ignore())
                .ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<CollectionEditModel, Collection>()
                .IncludeBase<CollectionCreateModel, Collection>()
                .ForMember(x => x.Id, x => x.MapFrom(c => c.Id));
            CreateMap<Collection, CollectionSimpleModel>()
                .ForMember(x => x.ItemsCount, x =>
                {
                    x.MapFrom(c => c.Items.Count);
                });
            CreateMap<Collection, CollectionDetailsModel>().IncludeBase<Collection, CollectionSimpleModel>();
        }
    }
}