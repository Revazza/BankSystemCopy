﻿// <auto-generated />
using System;
using CommonServices.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommonServices.Migrations
{
    [DbContext(typeof(BankSystemDbContext))]
    [Migration("20230316195541_newMigrations")]
    partial class newMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommonServices.Db.Entities.AccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                            Amount = 10771m,
                            Currency = 0,
                            Iban = "Ana's Iban",
                            UserId = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187")
                        },
                        new
                        {
                            Id = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                            Amount = 14052m,
                            Currency = 0,
                            Iban = "Sandro's Iban",
                            UserId = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4")
                        });
                });

            modelBuilder.Entity("CommonServices.Db.Entities.CardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<short>("Cvv")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Pin")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                            AccountId = new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                            CardNumber = "289294909038760701",
                            CreatedAt = new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8440),
                            Cvv = (short)931,
                            ExpiresAt = new DateTime(2028, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8436),
                            FullName = "Ana Mklavashvili",
                            Pin = (short)1234
                        },
                        new
                        {
                            Id = new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                            AccountId = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                            CardNumber = "130157007132422334",
                            CreatedAt = new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8455),
                            Cvv = (short)931,
                            ExpiresAt = new DateTime(2028, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(8454),
                            FullName = "Sandro Revazishvili",
                            Pin = (short)1234
                        });
                });

            modelBuilder.Entity("CommonServices.Db.Entities.CurrencyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Diff")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("DiffFormated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("RateFormated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFromDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CommonServices.Db.Entities.EmailRequestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailRequests");
                });

            modelBuilder.Entity("CommonServices.Db.Entities.OperatorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d"),
                            Name = "ana"
                        });
                });

            modelBuilder.Entity("CommonServices.Db.Entities.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyFrom")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyTo")
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CommonServices.Db.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

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
                            Id = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2013, 3, 16, 23, 55, 41, 313, DateTimeKind.Local).AddTicks(5501),
                            ConcurrencyStamp = "7578b361-0661-43ca-b068-62c81c2527f3",
                            Email = "anamklavashvili@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ana",
                            LastName = "Mklavashvili",
                            LockoutEnabled = false,
                            PasswordHash = "AF87tWO19C0G3YLdqBG8Q9q78p+DsLKKcgC+YhoI+ex2KBdRjWJO4aK0WV/AYYVIyQ==",
                            PersonalNumber = "348932282",
                            PhoneNumberConfirmed = false,
                            RegisteredAt = new DateTime(2023, 3, 16, 23, 55, 41, 313, DateTimeKind.Local).AddTicks(5540),
                            TwoFactorEnabled = false,
                            UserName = "ana"
                        },
                        new
                        {
                            Id = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2013, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(1921),
                            ConcurrencyStamp = "e280b57c-e6f6-4ae7-af3a-cf3ef05f4e5c",
                            Email = "sandro.revazishviliii@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Sandro",
                            LastName = "Revazishvili",
                            LockoutEnabled = false,
                            PasswordHash = "ABow13V1MlhYUmMTON+oJC47Pogj/FjAkUt9Ypr6fzo6g2ctxO4jXtLsV0tiojczlg==",
                            PersonalNumber = "629541122",
                            PhoneNumberConfirmed = false,
                            RegisteredAt = new DateTime(2023, 3, 16, 23, 55, 41, 314, DateTimeKind.Local).AddTicks(1923),
                            TwoFactorEnabled = false,
                            UserName = "sandro"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CommonServices.Db.Entities.AccountEntity", b =>
                {
                    b.HasOne("CommonServices.Db.Entities.UserEntity", "UserEntity")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("CommonServices.Db.Entities.CardEntity", b =>
                {
                    b.HasOne("CommonServices.Db.Entities.AccountEntity", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CommonServices.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CommonServices.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonServices.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CommonServices.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommonServices.Db.Entities.AccountEntity", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("CommonServices.Db.Entities.UserEntity", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}