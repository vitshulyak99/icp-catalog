using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Collections.DAL.Entities.Identity
{
    
    public sealed class AppUser : IdentityUser<int>
    {
        public AppUser(string name) : base(name)
        {
        }

        public AppUser() : base()
        {

        }
        public List<Comment> Comments { get; set; }
        public List<Collection> Collections { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
        
    }
}
