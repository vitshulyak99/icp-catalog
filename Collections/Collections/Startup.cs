using AutoMapper;
using Collections.DAL;
using Collections.General;
using Collections.Mapper;
using Markdig;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace Collections
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment){
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public void ConfigureServices(IServiceCollection services){
            services.AddAppDbContext(WebHostEnvironment,Configuration);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie()
                    .AddGoogle(
                        opt =>
                        {
                            opt.ClientId = !string.IsNullOrEmpty(Develop.Env.Google.ClientId)
                                ? Develop.Env.Google.ClientId
                                : Configuration["Authentication:Google:ClientId"];
                            opt.ClientSecret = !string.IsNullOrEmpty(Develop.Env.Google.ClientSecret)
                                ? Develop.Env.Google.ClientSecret
                                : Configuration["Authentication:Google:ClientSecret"];
                            opt.SignInScheme = IdentityConstants.ExternalScheme;
                        });
            services.AddAuthorization();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
            });
            services.AddMvc().AddRazorPagesOptions(opt =>
            {
                opt.Conventions.AuthorizeAreaFolder("Identity", "/Pages/Account");
            });

            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<MapperProfile>();
                x.AddProfile<TagProfile>();
                x.AddProfile<AppRoleProfile>();
                x.AddProfile<AppUserProfile>();
                x.AddProfile<CollectionProfile>();
                x.AddProfile<ItemProfile>();
                x.AddProfile<FieldProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            var pipline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            services.AddSingleton(pipline);
            services.AddServices();
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope()) scope.ServiceProvider.GetService<AppDbContext>()?.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //var options = new RewriteOptions()
            //    .AddRedirectToHttps();

            //app.UseRewriter(options);
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages().AllowAnonymous();
            });

        }
    }
}
