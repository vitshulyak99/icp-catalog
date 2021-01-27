using AutoMapper;
using Collections.DAL.Entities.Identity;
using Collections.Models;

namespace Collections.Mapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, RoleInfoModel>();
            CreateMap<AppUserRole, RoleInfoModel>()
                .ForMember(x => x.Id, x => x.MapFrom(c => c.RoleId))
                .ForMember(x => x.Name, x => x.MapFrom(c => c.Role.Name));
        }
    }
}