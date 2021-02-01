using System.Linq;
using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models.Comment;
using Collections.Models.Item;

namespace Collections.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemViewModel>()
                .ForMember(x => x.Likes, x => x.MapFrom(c => c.UserLike.Select(d => d.Id)))
                .ForMember(x => x.CollectionId, x => x.MapFrom(c => c.Collection.Id));
            CreateMap<Item, ItemSearchResultViewModel>()
                .IncludeBase<Item, ItemViewModel>()
                .ForMember(x => x.Collection, x => x.MapFrom(c => c.Collection));
            CreateMap<ItemCreateModel, Item>()
                .ForMember(x => x.Collection,
                    x => x.MapFrom(c => new Collection { Id = c.CollectionId }))
                .ForMember(x => x.UserLike, x => x.Ignore())
                .ForMember(x => x.Comments, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore());

            CreateMap<Item, ItemEditModel>()
                .IncludeBase<Item, ItemViewModel>();
            CreateMap<ItemEditModel, Item>().ForMember(x => x.Collection,
                                                x => x.MapFrom(c => new Collection { Id = c.CollectionId }))
                                            .ForMember(x => x.UserLike, x => x.Ignore())
                                            .ForMember(x => x.Comments, x => x.Ignore())
                                            .ForMember(x => x.Id, x => x.Ignore());

            CreateMap<Item, ItemSimpleViewModel>();
        }
    }
}