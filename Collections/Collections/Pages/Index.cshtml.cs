using System.Collections.Generic;
using System.Linq;
using Collections.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Collections.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _manager;

        public IndexModel(UserManager<AppUser> manager){
            _manager = manager;
        }

        public IEnumerable<(object Id, string Username)> UserNames =>
            _manager.Users.Select(u => new {u.Id, u.UserName})
                .ToArray()
                .Select(u => (u.Id as object, u.UserName));

        public void OnGet()
        {
        }
    }
}
