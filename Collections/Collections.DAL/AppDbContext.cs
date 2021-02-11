using System;
using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collections.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Like>(e => e.HasKey(x => new {x.ItemId, x.UserId}));
            builder.Entity<FieldValue>()
                   .HasGeneratedTsVectorColumn(x => x.SearchVector, "english", x => x.Value)
                   .HasIndex(x => x.SearchVector)
                   .HasMethod("GIN");

            builder.Entity<Field>()
                   .ToTable("FieldDef");

            builder.Entity<Collection>()
                   .HasGeneratedTsVectorColumn(x => x.SearchVector, "english", x => new {x.Description, x.Title})
                   .HasIndex(x => x.SearchVector)
                   .HasMethod("GIN");

            builder.Entity<Comment>()
                   .HasGeneratedTsVectorColumn(x => x.SearchVector, "english", x => x.Text)
                   .HasIndex(x => x.SearchVector)
                   .HasMethod("GIN");
            builder.Entity<Item>()
                   .HasGeneratedTsVectorColumn(x => x.SearchVector, "english", x => x.Name)
                   .HasIndex(x => x.SearchVector)
                   .HasMethod("GIN");

            builder.Entity<AppUserRole>(
                e =>
                {
                    e.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
                    e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
                });

            builder.Entity<Item>(e =>
            {
                e.HasMany(x => x.Likes)
                 .WithOne(x => x.Item)
                 .HasForeignKey(x => x.ItemId);
            });

            builder.Entity<AppUser>(e =>
            {
                e.HasMany(x => x.UserRoles).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
                
                e.HasMany(x => x.Likes)
                 .WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId);
            });
            
            builder.Entity<AppRole>(e =>
            {
                e.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            });

            builder.Entity<Theme>(
                e =>
                {
                    e.HasData(
                        new Theme("Alcohol") {Id = 1},
                        new Theme("Cars") {Id = 2},
                        new Theme("Books") {Id = 3},
                        new Theme("Games") {Id = 4});
                });

            #region identity

            var passwordHasher = new PasswordHasher<AppUser>();
            var adminRole = new AppRole(Constants.Roles.Admin)
            {
                Id = 1,
            };
            var customerRole = new AppRole(Constants.Roles.Customer) {Id = 2};
            var adminUser = new AppUser(Constants.Roles.Admin)
            {
                Id = 1,
                Email = "admin@icp.cc",
                NormalizedEmail = "admin@icp.cc",
                UserName = "admin@icp.cc".ToUpper(),
                NormalizedUserName = "admin@icp.cc".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "!Pass123"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<AppRole>(
                e => { e.HasData(adminRole); });
            builder.Entity<AppUser>(
                e => { e.HasData(adminUser); });
            builder.Entity<IdentityUserRole<int>>(
                e =>
                {
                    e.HasData(
                        new IdentityUserRole<int>()
                        {
                            RoleId = adminRole.Id,
                            UserId = adminUser.Id
                        });
                });

            #endregion

            builder.Entity<Tag>()
                   .HasData(new Tag(1, "Car"), new Tag(2, "Alcohol"), new Tag(3, "Book"),new Tag(4,"Game"));
        }
    }
}