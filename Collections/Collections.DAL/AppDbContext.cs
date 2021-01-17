using Collections.DAL.Entities;
using Collections.DAL.Entities.Identity;
using Collections.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collections.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<CollectionItemTag> ItemsTags { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Collection>(
                e =>
                {
                    e.HasMany(x => x.Fields)
                        .WithOne(x => x.Collection)
                        .HasForeignKey(x => x.CollectionId);
                    e.HasMany(x => x.Items)
                        .WithOne(x => x.Collection)
                        .HasForeignKey(x => x.CollectionId);
                });
            builder.Entity<CollectionItem>(
                e =>
                {
                    e.HasOne(x => x.Collection)
                        .WithMany(x => x.Items)
                        .HasForeignKey(x => x.CollectionId);
                });

            builder.Entity<CollectionItemTag>(
                e =>
                {
                    e.HasKey(x => new { x.CollectionItemId, x.TagId });
                    e.HasOne(x => x.Tag)
                        .WithMany(x => x.ItemTags)
                        .HasForeignKey(x => x.TagId);
                    e.HasOne(x => x.CollectionItem)
                        .WithMany(x => x.ItemsTags)
                        .HasForeignKey(x => x.CollectionItemId);
                });
            builder.Entity<CustomField>(
                e =>
                {
                    e.HasOne(x => x.Collection)
                        .WithMany(x => x.Fields)
                        .HasForeignKey(x => x.CollectionId);
                });
            builder.Entity<CustomFieldValue>(
                e =>
                {
                    e.HasOne(x => x.CollectionItem)
                        .WithMany(x => x.CustomFieldValues)
                        .HasForeignKey(x => x.CollectionItemId);
                    e.HasOne(x => x.CustomField)
                        .WithMany(x => x.Values)
                        .HasForeignKey(x => x.CustomFieldId);
                });

            #region identity

            var passwordHasher = new PasswordHasher<AppUser>();
            var adminRole = new AppRole(Constants.Roles.Admin) { Id = 1 };
            var customerRole = new AppRole(Constants.Roles.Customer) { Id = 2 };
            var adminUser = new AppUser(Constants.Roles.Admin)
            {
                Id = 1,
                Email = "admin@icp.cc",
                NormalizedEmail = "admin@icp.cc",
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "!Admin123")
            };
            var customerUser = new AppUser(Constants.Roles.Customer)
            {
                Id = 2,
                Email = "user@icp.cc",
                NormalizedEmail = "user@icp.cc",
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "!User123")
            };

            builder.Entity<AppRole>(
                e =>
                {
                    e.HasData(adminRole, customerRole);
                });
            builder.Entity<AppUser>(
                e =>
                {
                    e.HasData(adminUser, customerUser);
                });
            builder.Entity<IdentityUserRole<int>>(
                e =>
                {
                    e.HasData(
                        new IdentityUserRole<int>()
                        {
                            RoleId = adminRole.Id,
                            UserId = adminUser.Id
                        },
                        new IdentityUserRole<int>()
                        {
                            RoleId = customerRole.Id,
                            UserId = customerUser.Id
                        });
                });

            #endregion
        }
    }
}