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
                .ForMember(x => x.Collection, x => x.Ignore())
                .ForMember(x=>x.Values,x=>x.Ignore());

            CreateMap<Field, FieldModel>();

            CreateMap<FieldValue, FieldValueModel>()
                .ForMember(x=>x.FieldId, x=>x.MapFrom(c=>c.Field.Id));
            CreateMap<FieldValue, FieldValueViewModel>()
                .IncludeBase<FieldValue, FieldValueModel>();
            CreateMap<FieldValueModel, FieldValue>()
                .ForMember(x => x.Field, x => x.MapFrom(c => new Field
                {
                    Id = c.FieldId
                }))
                .ForMember(x => x.Item, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore());
          

        }
    }
}