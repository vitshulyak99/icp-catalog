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
        public List<Comment> Comments { get; set; } = new();
        public List<Collection> Collections { get; set; } = new();
        public List<AppUserRole> UserRoles { get; set; } = new();
        public List<Item> LikedItems { get; set; } = new();
    }
}
