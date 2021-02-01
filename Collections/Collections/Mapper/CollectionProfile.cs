using AutoMapper;
using Collections.DAL.Entities;
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
                .ForMember(x => x.Id, x => x.Ignore());
            CreateMap<CollectionCreateModel, Collection>()
                .ForMember(x => x.Theme, x => x.MapFrom(c => new Theme { Id = c.Theme }))
                .ForMember(x => x.Owner, x => x.Ignore())
                .ForMember(x => x.Items, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore());
            CreateMap<CollectionSimpleModel, Collection>()
                .IncludeBase<CollectionModel, Collection>()
                .ForMember(x => x.Fields, x => x.Ignore())
                .ForMember(x => x.Items, x => x.Ignore())
                .ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<CollectionEditModel, Collection>()
                .IncludeBase<CollectionModel, Collection>()
                .ForMember(x => x.Theme, x => x.MapFrom(c => new Theme { Id = c.Id }));
            CreateMap<Collection, CollectionModel>();
            CreateMap<Collection, CollectionSimpleModel>()
                .IncludeBase<Collection, CollectionModel>()
                .ForMember(x => x.ItemsCount, x =>
                {
                    x.MapFrom(c => c.Items.Count);
                })
                .ForMember(x=>x.Fields,x=>x.MapFrom(c=>c.Fields));

            CreateMap<Collection, CollectionEditViewModel>()
                .IncludeBase<Collection, CollectionModel>()
                .ForMember(x => x.Id, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.Themes, x => x.Ignore());
            CreateMap<Collection, CollectionDetailsModel>().IncludeBase<Collection, CollectionSimpleModel>();
        }
    }
}