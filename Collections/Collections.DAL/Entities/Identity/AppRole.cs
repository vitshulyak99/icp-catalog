using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Collections.DAL.Entities.Identity
{
    public sealed class AppRole : IdentityRole<int>
    {
        public AppRole(string name) : base(name){
            NormalizedName = name.ToUpper();
        }

        public AppRole() : base()
        {
        }

        public List<AppUserRole> UserRoles { get; set; }
    }
}
