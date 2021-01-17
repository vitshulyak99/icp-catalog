using Collections.DAL.Entities.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Collections.General;

namespace Collections.DAL
{
    public static class Startup
    {
        

        public static IServiceCollection AddAppDbContext(this IServiceCollection self, IWebHostEnvironment environment, IConfiguration configuration)
        {
            var connectionString = Develop.IsDeploy
                ? Develop.HerokuConnectionString()
                : configuration.GetConnectionString("Default");
            self.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
            self.AddIdentity<AppUser, AppRole>()
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddUserManager<UserManager<AppUser>>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddDefaultTokenProviders();

            return self;
        }
    }
}