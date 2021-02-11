using AutoMapper;
using Collections.DAL.Entities;
using Services.Dto; 

namespace Collections.Mapper
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {

            CreateMap<Field, FieldDto>();
            CreateMap<FieldDto, Field>()
                .ForMember(d=>d.SearchVector,opt=>opt.Ignore())
                .ForMember(d=>d.Values,opt=>opt.Ignore())
                .ForMember(d=>d.Collection,opt=>opt.Ignore());

            CreateMap<FieldValue, FieldValueDto>();
            CreateMap<FieldValueDto, FieldValue>()
                .ForMember(d=>d.SearchVector,opt=>opt.Ignore())
                .ForMember(d=>d.Item,opt=>opt.Ignore());
        }
    }
}