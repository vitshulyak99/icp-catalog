﻿// <auto-generated />
using System;
using Collections.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Collections.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AppUserItem", b =>
                {
                    b.Property<int>("LikedItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("UserLikeId")
                        .HasColumnType("integer");

                    b.HasKey("LikedItemsId", "UserLikeId");

                    b.HasIndex("UserLikeId");

                    b.ToTable("LikedItems");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ThemeId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ThemeId");

                    b.HasIndex("Title", "Description")
                        .HasMethod("GIN")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int?>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("SenderId");

                    b.HasIndex("Text")
                        .HasMethod("GIN")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("FieldDef");
                });

            modelBuilder.Entity("Collections.DAL.Entities.FieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("FieldId")
                        .HasColumnType("integer");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("ItemId");

                    b.HasIndex("Value")
                        .HasMethod("GIN")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english");

                    b.ToTable("FieldValue");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "09b34519-29fa-486e-a56c-3549e619f1e0",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "63501b9e-c2fd-4c54-80b2-4ff5e07d60c9",
                            Email = "admin@icp.cc",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@icp.cc",
                            NormalizedUserName = "ADMIN@ICP.CC",
                            PasswordHash = "AQAAAAEAACcQAAAAECn17+0UpnoolZpYfp64oP2fPvBJVSKCM+2oKyH3VbeaPXgmYqIQjq6my60dPXDucA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8be16886-2315-4448-8619-e3115dc3850b",
                            TwoFactorEnabled = false,
                            UserName = "ADMIN@ICP.CC"
                        });
                });

            modelBuilder.Entity("Collections.DAL.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("Name")
                        .HasMethod("GIN")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SomeTag"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SomeTag2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lamba"
                        });
                });

            modelBuilder.Entity("Collections.DAL.Entities.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Themes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alcohol"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Games"
                        });
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.Property<int>("ItemTagsId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("ItemTagsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ItemTag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<int>");

                    b.Property<int?>("AppRoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("integer");

                    b.HasIndex("AppRoleId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("AppUserRole");
                });

            modelBuilder.Entity("AppUserItem", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("LikedItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserLikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Collections.DAL.Entities.Collection", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", "Owner")
                        .WithMany("Collections")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Collections.DAL.Entities.Theme", "Theme")
                        .WithMany("Collections")
                        .HasForeignKey("ThemeId");

                    b.Navigation("Owner");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Comment", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId");

                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", "Sender")
                        .WithMany("Comments")
                        .HasForeignKey("SenderId");

                    b.Navigation("Item");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Field", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Collection", "Collection")
                        .WithMany("Fields")
                        .HasForeignKey("CollectionId");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Collections.DAL.Entities.FieldValue", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Field", "Field")
                        .WithMany("Values")
                        .HasForeignKey("FieldId");

                    b.HasOne("Collections.DAL.Entities.Item", "Item")
                        .WithMany("Fields")
                        .HasForeignKey("ItemId");

                    b.Navigation("Field");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Item", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Collections.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppUserRole", b =>
                {
                    b.HasOne("Collections.DAL.Entities.Identity.AppRole", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("AppRoleId");

                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Collections.DAL.Entities.Identity.AppRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Collections.DAL.Entities.Identity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Collection", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Field", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Comments");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Item", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Collections.DAL.Entities.Theme", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
