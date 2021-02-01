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
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<FieldValue>().ToTable("FieldValue")
                   .HasIndex(x => new { x.Value })
                   .IsTsVectorExpressionIndex("english")
                   .HasMethod("GIN");

            builder.Entity<Field>()
                   .ToTable("FieldDef");

            builder.Entity<Collection>().HasIndex(x => new { x.Title, x.Description })
                   .IsTsVectorExpressionIndex("english")
                   .HasMethod("GIN");

            builder.Entity<Comment>()
                   .HasIndex(x => x.Text)
                   .IsTsVectorExpressionIndex("english")
                   .HasMethod("GIN");
            builder.Entity<Item>()
                   .HasIndex(x => new { ItemName = x.Name })
                   .IsTsVectorExpressionIndex("english")
                   .HasMethod("GIN");

            builder.Entity<AppUserRole>(
                e =>
                {
                    e.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
                    e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
                });

            builder.Entity<Item>(e =>
            {
                e.HasMany(x => x.UserLike)
                 .WithMany(x => x.LikedItems)
                 .UsingEntity(x=>x.ToTable("LikedItems"));
            });

            builder.Entity<Theme>(
                e =>
                {
                    e.HasData(
                        new Theme("Alcohol") { Id = 1 },
                        new Theme("Cars") { Id = 2 },
                        new Theme("Books") { Id = 3 },
                        new Theme("Games") { Id = 4 });
                });
            #region identity

            var passwordHasher = new PasswordHasher<AppUser>();
            var adminRole = new AppRole(Constants.Roles.Admin)
            {
                Id = 1,
            };
            var customerRole = new AppRole(Constants.Roles.Customer) { Id = 2 };
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
                e =>
                {
                    e.HasData(adminRole);
                });
            builder.Entity<AppUser>(
                e =>
                {
                    e.HasData(adminUser);
                });
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
                   .HasData(new Tag(1, "SomeTag"), new Tag(2, "SomeTag2"), new Tag(3, "Lamba"));
        }
    }
}
