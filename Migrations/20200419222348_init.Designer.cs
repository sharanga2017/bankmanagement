﻿// <auto-generated />
using System;
using BankManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200419222348_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankManagement.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "fsdfsdfsdfsdf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92b1bd18-f778-4fa3-ac11-cc0a6450fe94",
                            Email = "mary@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "fsdhfjkqhldjfhsldfjksdhlq",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "serguei"
                        });
                });

            modelBuilder.Entity("BankManagement.Models.PrimaryAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UniqueId");

                    b.Property<string>("UserRef");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique()
                        .HasFilter("[UserRef] IS NOT NULL");

                    b.ToTable("PrimaryAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 787987m,
                            CreatedOn = new DateTime(2020, 4, 20, 0, 23, 48, 428, DateTimeKind.Local).AddTicks(1521),
                            Name = "PAccount Serguei",
                            UniqueId = 0,
                            UserRef = "fsdfsdfsdfsdf"
                        });
                });

            modelBuilder.Entity("BankManagement.Models.PrimaryTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("PrimaryAccountId");

                    b.Property<string>("Status");

                    b.Property<int?>("TransactionType");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryAccountId");

                    b.ToTable("PrimaryTransactions");
                });

            modelBuilder.Entity("BankManagement.Models.SavingsAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UniqueId");

                    b.Property<string>("UserRef");

                    b.HasKey("Id");

                    b.HasIndex("UserRef")
                        .IsUnique()
                        .HasFilter("[UserRef] IS NOT NULL");

                    b.ToTable("SavingsAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 7987m,
                            CreatedOn = new DateTime(2020, 4, 20, 0, 23, 48, 430, DateTimeKind.Local).AddTicks(7128),
                            Name = "SAccount Serguei",
                            UniqueId = 0,
                            UserRef = "fsdfsdfsdfsdf"
                        });
                });

            modelBuilder.Entity("BankManagement.Models.SavingsTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("SavingsAccountId");

                    b.Property<string>("Status");

                    b.Property<int?>("TransactionType");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("SavingsAccountId");

                    b.ToTable("SavingsTransactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BankManagement.Models.PrimaryAccount", b =>
                {
                    b.HasOne("BankManagement.Models.ApplicationUser", "User")
                        .WithOne("PrimaryAccount")
                        .HasForeignKey("BankManagement.Models.PrimaryAccount", "UserRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BankManagement.Models.PrimaryTransaction", b =>
                {
                    b.HasOne("BankManagement.Models.PrimaryAccount", "PrimaryAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("PrimaryAccountId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BankManagement.Models.SavingsAccount", b =>
                {
                    b.HasOne("BankManagement.Models.ApplicationUser", "User")
                        .WithOne("SavingsAccount")
                        .HasForeignKey("BankManagement.Models.SavingsAccount", "UserRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BankManagement.Models.SavingsTransaction", b =>
                {
                    b.HasOne("BankManagement.Models.SavingsAccount", "SavingsAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("SavingsAccountId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BankManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BankManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BankManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BankManagement.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
