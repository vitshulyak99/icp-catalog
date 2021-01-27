using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models.Item;

namespace Collections.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemViewModel>();
        }
    }
}