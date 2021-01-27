using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Collections.DAL.Entities.Identity
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}