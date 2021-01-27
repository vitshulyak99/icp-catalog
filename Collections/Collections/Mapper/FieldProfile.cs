using AutoMapper;
using Collections.DAL.Entities;
using Collections.Models.Collection;
using Collections.Models.Item;

namespace Collections.Mapper
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {

            CreateMap<FieldCreateModel, Field>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.Collection, x => x.Ignore());
             
            CreateMap<Field, FieldModel>();

            CreateMap<FieldValue, FieldValueModel>();
        }
    }
}