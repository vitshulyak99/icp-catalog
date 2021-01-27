using System.Collections.Generic;

namespace Collections.Models
{
    public class UserInfoWithRolesModel : SimpleUserInfoModel
    {
        public List<RoleInfoModel> Roles { get; set; }
    }

    public class SimpleUserInfoModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}