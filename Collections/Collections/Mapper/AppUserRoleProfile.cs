using AutoMapper;
using Collections.DAL.Entities.Identity;
using Services.Dto;

namespace Collections.Mapper
{
    public class AppUserRoleProfile : Profile
    {
        public AppUserRoleProfile()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(x=>x.Email, opt=>opt.MapFrom(s=>s.Email))
                .ForMember(x=>x.UserName, opt=>opt.MapFrom(s=>s.UserName))
                .ForMember(x=>x.Email, opt=>opt.MapFrom(s=>s.Email))
                .ForMember(d=>d.Roles,opt=>opt.MapFrom(s=>s.UserRoles))
                .ForMember(d=>d.Password, opt => opt.Ignore());
            CreateMap<UserDto,AppUser >()
                .ForAllMembers(opt=>opt.Ignore());
            CreateMap<AppRole, RoleDto>();
            CreateMap<AppUserRole, RoleDto>()
                .ForMember(d=>d.Id, opt=>opt.MapFrom(s=>s.Role.Id))
                .ForMember(d=>d.Name, opt=>opt.MapFrom(s=>s.Role.Name));
        }
    }
}