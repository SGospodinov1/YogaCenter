﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YogaCenter.Infrastructure.Data;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a9102582-a6f9-4730-8dc6-59644bc1a460",
                            ConcurrencyStamp = "9ad4d36c-baac-4973-9b82-29ed851c69bb",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e6e1e8c8-e42c-4ab8-99e7-8a01a3a068fa",
                            Email = "teacher@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Kristiana",
                            LastName = "Bakalova",
                            LockoutEnabled = false,
                            NormalizedEmail = "teacher@mail.com",
                            NormalizedUserName = "teacher@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAwoHIb6dlzIX+l1qTVZl+8n00k/sHfA38CAm4Jk+AScgFxIHpw6ujkv6xrfLClLiA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "120db779-db56-4c7c-8fd3-69cb38038160",
                            TwoFactorEnabled = false,
                            UserName = "teacher@mail.com"
                        },
                        new
                        {
                            Id = "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "572a8f3a-585c-4cdf-be0d-dd32b7a581d8",
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Maria",
                            LastName = "Petrova",
                            LockoutEnabled = false,
                            NormalizedEmail = "user@mail.com",
                            NormalizedUserName = "user@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECacrwXiTs2O+b3j/yCV49MInVuhuNB08q9L7fzEtQxwfx0CAr4Bl264jPmSrJVvRA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a896fdd9-60d2-4efe-b698-49e87043e8f5",
                            TwoFactorEnabled = false,
                            UserName = "user@mail.com"
                        },
                        new
                        {
                            Id = "f01035fc-9c12-4f86-a01a-5fe5ce4d5dd2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9ba03e77-1dd7-48ff-9f3c-6e324120e300",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Stoyan",
                            LastName = "Gospodinov",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEN1DKVAdmmvgLk0b7RGdiv3tOsPjnsutwxTHTQw4S7cTMyQGHq5ei/X1SGXcU96KQA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ae7dfd4c-5b6f-47d1-91b5-6ff852e1c147",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hatha Yoga"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ashtanga Yoga"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Iyengar Yoga"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Viniasa Yoga"
                        },
                        new
                        {
                            Id = 5,
                            Name = "In Yoga"
                        });
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUserId = "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                            Description = "I`m a yoga teacher."
                        });
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUserId = "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c"
                        });
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.UserYogaClass", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("YogaClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "YogaClassId");

                    b.HasIndex("YogaClassId");

                    b.ToTable("UserYogaClass");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.YogaClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeacherId");

                    b.ToTable("YogaClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            EndTime = new DateTime(2022, 11, 11, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            IsEdited = false,
                            Name = "Balance and clear your mind",
                            Price = 15m,
                            StartTime = new DateTime(2022, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            EndTime = new DateTime(2022, 11, 11, 21, 30, 0, 0, DateTimeKind.Unspecified),
                            IsEdited = false,
                            Name = "Dinamic Viniasa with Krisi",
                            Price = 20m,
                            StartTime = new DateTime(2022, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Post", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.Teacher", "Teacher")
                        .WithMany("Posts")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.User", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.UserYogaClass", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.User", "User")
                        .WithMany("UsersYogaClasses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.YogaClass", "YogaClass")
                        .WithMany("UsersYogaClasses")
                        .HasForeignKey("YogaClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("YogaClass");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.YogaClass", b =>
                {
                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.Category", "Category")
                        .WithMany("YogaClasses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YogaCenter.Infrastructure.Data.DataModels.Teacher", "Teacher")
                        .WithMany("YogaClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Category", b =>
                {
                    b.Navigation("YogaClasses");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("YogaClasses");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.User", b =>
                {
                    b.Navigation("UsersYogaClasses");
                });

            modelBuilder.Entity("YogaCenter.Infrastructure.Data.DataModels.YogaClass", b =>
                {
                    b.Navigation("UsersYogaClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
