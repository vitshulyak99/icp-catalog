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
        

        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            var connectionString = Develop.IsDeploy
                ? Develop.HerokuConnectionString()
                : configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
            services.AddIdentity<AppUser, AppRole>()
                .AddRoles<AppRole>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddUserManager<UserManager<AppUser>>()
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}