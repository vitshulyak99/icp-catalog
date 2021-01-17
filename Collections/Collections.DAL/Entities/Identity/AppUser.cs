using Microsoft.AspNetCore.Identity;

namespace Collections.DAL.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser(string name) : base(name) { }

        public AppUser() : base() { }
    }
}
