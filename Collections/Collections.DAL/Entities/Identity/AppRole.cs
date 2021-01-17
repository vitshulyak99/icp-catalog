using Microsoft.AspNetCore.Identity;

namespace Collections.DAL.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole(string name) : base(name) { }
        public AppRole() : base() { }
    }
}