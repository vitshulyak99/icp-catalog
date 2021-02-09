using AutoMapper;
using Collections.DAL;
using Collections.Jwt;
using Collections.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Services;
using Newtonsoft.Json.Serialization;

namespace Collections
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:3000");
                });
            });

            services.AddAppDbContext(Configuration);
            var jwtConfiguration = new JwtConfigurationBuilder(Configuration).Build();
            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidAudience = jwtConfiguration.Audience,
                            ValidIssuer = jwtConfiguration.Issuer,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            IssuerSigningKey = jwtConfiguration.GetSecurityKey(),
                            ValidateIssuerSigningKey = true
                        };
                    });
                    // .AddGoogle(
                    //     opt =>
                    //     {
                    //         opt.ClientId = !string.IsNullOrEmpty(Develop.Env.Google.ClientId)
                    //             ? Develop.Env.Google.ClientId
                    //             : Configuration["Authentication:Google:ClientId"];
                    //         opt.ClientSecret = !string.IsNullOrEmpty(Develop.Env.Google.ClientSecret)
                    //             ? Develop.Env.Google.ClientSecret
                    //             : Configuration["Authentication:Google:ClientSecret"];
                    //         opt.SignInScheme = IdentityConstants.ExternalScheme;
                    //     });
            services.AddAuthorization();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
                


            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<ThemeProfile>();
                x.AddProfile<TagProfile>();
                x.AddProfile<AppUserRoleProfile>();
                x.AddProfile<CollectionProfile>();
                x.AddProfile<ItemProfile>();
                x.AddProfile<FieldProfile>();
                x.AddProfile<CommentProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper)
                    .AddSingleton(jwtConfiguration)
                    .AddSingleton<JwtTokenProvider>()
                    .AddServices();
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

            app.UseCors("VueCorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
