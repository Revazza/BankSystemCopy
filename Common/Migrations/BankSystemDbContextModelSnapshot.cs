﻿// <auto-generated />
using System;
using BankSystem.Common.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankSystem.Common.Migrations
{
    [DbContext(typeof(BankSystemDbContext))]
    partial class BankSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankSystem.Common.Db.Entities.AccountEntity", b =>
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
                            Amount = 13555m,
                            Currency = 0,
                            Iban = "AnaIban",
                            UserId = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187")
                        },
                        new
                        {
                            Id = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                            Amount = 19131m,
                            Currency = 0,
                            Iban = "SandroIban",
                            UserId = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4")
                        });
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.CardEntity", b =>
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

                    b.Property<string>("Cvv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                            AccountId = new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                            CardNumber = "273525361259132791",
                            CreatedAt = new DateTime(2023, 4, 7, 10, 57, 34, 601, DateTimeKind.Local).AddTicks(211),
                            Cvv = "931",
                            ExpiresAt = new DateTime(2028, 4, 7, 10, 57, 34, 601, DateTimeKind.Local).AddTicks(187),
                            FullName = "Ana Mklavashvili",
                            Pin = "1234"
                        },
                        new
                        {
                            Id = new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                            AccountId = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                            CardNumber = "663511083436562936",
                            CreatedAt = new DateTime(2023, 4, 7, 10, 57, 34, 601, DateTimeKind.Local).AddTicks(223),
                            Cvv = "931",
                            ExpiresAt = new DateTime(2028, 4, 7, 10, 57, 34, 601, DateTimeKind.Local).AddTicks(222),
                            FullName = "Sandro Revazishvili",
                            Pin = "1234"
                        });
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.CurrencyEntity", b =>
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

            modelBuilder.Entity("BankSystem.Common.Db.Entities.EmailRequestEntity", b =>
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

            modelBuilder.Entity("BankSystem.Common.Db.Entities.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountFromIban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AccountFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountToIban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AccountToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyFrom")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyTo")
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("ReceivedAmount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<decimal>("WithDrawnAmount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("51a5b332-5573-4a37-a022-9b7a05da9b1a"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 1,
                            CurrencyTo = 2,
                            Fee = 29.80m,
                            ReceivedAmount = 567.20m,
                            TransactionType = 1,
                            WithDrawnAmount = 325m
                        },
                        new
                        {
                            Id = new Guid("894b08c9-0a0a-4f83-a90e-8fda0b38911d"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 2,
                            CurrencyTo = 0,
                            Fee = 18.50m,
                            ReceivedAmount = 438.10m,
                            TransactionType = 2,
                            WithDrawnAmount = 217.23m
                        },
                        new
                        {
                            Id = new Guid("7a48d6a4-53f1-416e-8644-519baf7a3272"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 0,
                            CurrencyTo = 1,
                            Fee = 34.23m,
                            ReceivedAmount = 900m,
                            TransactionType = 0,
                            WithDrawnAmount = 1034.23m
                        },
                        new
                        {
                            Id = new Guid("c8033c88-b015-45c9-b8bc-7c1460502693"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 1,
                            CurrencyTo = 2,
                            Fee = 16.20m,
                            ReceivedAmount = 312.70m,
                            TransactionType = 2,
                            WithDrawnAmount = 100.87m
                        },
                        new
                        {
                            Id = new Guid("1dfb36d6-922e-4f8b-b46d-838bc87ef93e"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 0,
                            CurrencyTo = 1,
                            Fee = 23.12m,
                            ReceivedAmount = 200m,
                            TransactionType = 0,
                            WithDrawnAmount = 223.12m
                        },
                        new
                        {
                            Id = new Guid("d1bae497-ec3c-43d0-8b74-6b54fef8732d"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 2,
                            CurrencyTo = 0,
                            Fee = 22.40m,
                            ReceivedAmount = 489.80m,
                            TransactionType = 1,
                            WithDrawnAmount = 354.23m
                        },
                        new
                        {
                            Id = new Guid("592e8097-d39f-4a99-a1d2-f932be321f95"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 1,
                            CurrencyTo = 0,
                            Fee = 31.50m,
                            ReceivedAmount = 637.90m,
                            TransactionType = 2,
                            WithDrawnAmount = 152.73m
                        },
                        new
                        {
                            Id = new Guid("ff3bff34-3333-4723-ba19-7a5054b7e9a0"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 0,
                            CurrencyTo = 1,
                            Fee = 27.87m,
                            ReceivedAmount = 600m,
                            TransactionType = 0,
                            WithDrawnAmount = 627.87m
                        },
                        new
                        {
                            Id = new Guid("a7919672-9625-40a0-a19c-8c0976e7775c"),
                            AccountFromId = new Guid("00000000-0000-0000-0000-000000000000"),
                            AccountToId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyFrom = 2,
                            CurrencyTo = 0,
                            Fee = 23.12m,
                            ReceivedAmount = 230m,
                            TransactionType = 0,
                            WithDrawnAmount = 253.12m
                        });
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.UserEntity", b =>
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
                            BirthDate = new DateTime(2013, 4, 7, 10, 57, 34, 599, DateTimeKind.Local).AddTicks(3147),
                            ConcurrencyStamp = "fead15c6-69af-485b-aa21-5cc2d481c12b",
                            Email = "anamklavashvili@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ana",
                            LastName = "Mklavashvili",
                            LockoutEnabled = false,
                            NormalizedEmail = "ANAMKLAVASHVILI@GMAIL.COM",
                            PasswordHash = "AFDAu0xtIHN49SKJofO3JWem5A1aWTSr/MEjH68hvVCla+p4OzcEIlSlKyMoez4QcQ==",
                            PersonalNumber = "14001025322",
                            PhoneNumberConfirmed = false,
                            RegisteredAt = new DateTime(2023, 4, 7, 10, 57, 34, 599, DateTimeKind.Local).AddTicks(3171),
                            SecurityStamp = "82d1a096-64b6-4c81-9279-778db7b1719f",
                            TwoFactorEnabled = false,
                            UserName = "ana"
                        },
                        new
                        {
                            Id = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2013, 4, 7, 10, 57, 34, 600, DateTimeKind.Local).AddTicks(1473),
                            ConcurrencyStamp = "aaf7fa62-7520-4836-b801-f08811ff0fba",
                            Email = "sandro.revazishviliii@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Sandro",
                            LastName = "Revazishvili",
                            LockoutEnabled = false,
                            NormalizedEmail = "SANDRO.REVAZISHVILIII@GMAIL.COM",
                            PasswordHash = "AMa6h0POWoEor1fwdKWHOQxifkS61zm7d9bgTCT5pzzMkrR/ISKn686QhsKtkoIqHg==",
                            PersonalNumber = "01001088032",
                            PhoneNumberConfirmed = false,
                            RegisteredAt = new DateTime(2023, 4, 7, 10, 57, 34, 600, DateTimeKind.Local).AddTicks(1498),
                            SecurityStamp = "81b0a16b-e6ef-4964-ab43-993d57615641",
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"),
                            Name = "api-user",
                            NormalizedName = "API-USER"
                        },
                        new
                        {
                            Id = new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"),
                            Name = "api-operator",
                            NormalizedName = "API-OPERATOR"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                            RoleId = new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f")
                        },
                        new
                        {
                            UserId = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                            RoleId = new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f")
                        });
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

            modelBuilder.Entity("BankSystem.Common.Db.Entities.AccountEntity", b =>
                {
                    b.HasOne("BankSystem.Common.Db.Entities.UserEntity", "UserEntity")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.CardEntity", b =>
                {
                    b.HasOne("BankSystem.Common.Db.Entities.AccountEntity", "Account")
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
                    b.HasOne("BankSystem.Common.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BankSystem.Common.Db.Entities.UserEntity", null)
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

                    b.HasOne("BankSystem.Common.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BankSystem.Common.Db.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.AccountEntity", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("BankSystem.Common.Db.Entities.UserEntity", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
