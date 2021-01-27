using AutoMapper;
using Collections.DAL.Entities.Identity;
using Collections.Models;

namespace Collections.Mapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserRole,SimpleUserInfoModel>()
                .ForMember(x => x.Id, x => x.MapFrom(c => c.UserId))
                .ForMember(x => x.UserName, x => x.MapFrom(c => c.User.UserName))
                .ForMember(x=>x.Email,x=>x.MapFrom(c=>c.User.Email));
            CreateMap<AppUser, SimpleUserInfoModel>();
            CreateMap<AppUser, UserInfoWithRolesModel>()
                .IncludeBase<AppUser, SimpleUserInfoModel>()
                .ForMember(x => x.Roles, 
                    x => x.MapFrom(x => x.UserRoles));
        }
    }
}