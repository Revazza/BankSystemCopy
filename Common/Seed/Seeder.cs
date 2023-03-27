using BankSystem.Common.Db.Entities;
using BankSystem.Common.Db.FinancialEnums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BankSystem.Common.Seed
{
    public static class Seeder
    {
        public static void SeedFakeTransactions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>()
                .HasData(
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 567.20m,
                        CreatedAt = new DateTime(2023, 3, 2),
                        CurrencyFrom = CurrencyType.USD,
                        CurrencyTo = CurrencyType.EUR,
                        Fee = 29.80m,
                        TransactionType = TransactionType.Inner
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 438.10m,
                        CreatedAt = new DateTime(2023, 3, 10),
                        CurrencyFrom = CurrencyType.EUR,
                        CurrencyTo = CurrencyType.GEL,
                        Fee = 18.50m,
                        TransactionType = TransactionType.Outer
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 789.40m,
                        CreatedAt = new DateTime(2023, 3, 18),
                        CurrencyFrom = CurrencyType.GEL,
                        CurrencyTo = CurrencyType.USD,
                        Fee = 33.20m,
                        TransactionType = TransactionType.ATM
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 312.70m,
                        CreatedAt = new DateTime(2022, 10, 12),
                        CurrencyFrom = CurrencyType.USD,
                        CurrencyTo = CurrencyType.EUR,
                        Fee = 16.20m,
                        TransactionType = TransactionType.Outer
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 195.50m,
                        CreatedAt = new DateTime(2022, 12, 23),
                        CurrencyFrom = CurrencyType.GEL,
                        CurrencyTo = CurrencyType.USD,
                        Fee = 9.80m,
                        TransactionType = TransactionType.ATM
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 489.80m,
                        CreatedAt = new DateTime(2022, 8, 7),
                        CurrencyFrom = CurrencyType.EUR,
                        CurrencyTo = CurrencyType.GEL,
                        Fee = 22.40m,
                        TransactionType = TransactionType.Inner
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 637.90m,
                        CreatedAt = new DateTime(2022, 1, 2),
                        CurrencyFrom = CurrencyType.USD,
                        CurrencyTo = CurrencyType.GEL,
                        Fee = 31.50m,
                        TransactionType = TransactionType.Outer
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 573.40m,
                        CreatedAt = new DateTime(2022, 5, 19),
                        CurrencyFrom = CurrencyType.GEL,
                        CurrencyTo = CurrencyType.USD,
                        Fee = 27.80m,
                        TransactionType = TransactionType.ATM
                    },
                    new TransactionEntity()
                    {
                        AccountFromId = Guid.Empty,
                        AccountToId = Guid.Empty,
                        Amount = 242.10m,
                        CreatedAt = new DateTime(2022, 11, 14),
                        CurrencyFrom = CurrencyType.EUR,
                        CurrencyTo = CurrencyType.GEL,
                        Fee = 23.12m,
                        TransactionType = TransactionType.ATM
                    }
                );
        }
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>()
                .HasData(
                    new IdentityRole<Guid>()
                    {
                        Id = new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f"),
                        Name = "api-user",
                        NormalizedName = "API-USER",
                    },
                    new IdentityRole<Guid>()
                    {
                        Id = new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"),
                        Name = "api-operator",
                        NormalizedName = "API-OPERATOR",
                    }
                );
        }

        public static void SeedUserEntityRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasData(
                    new IdentityUserRole<Guid>()
                    {
                        UserId = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                        RoleId = new Guid("3f66ed5d-b94b-46a7-a9c3-9a564241708f"),
                    },
                    new IdentityUserRole<Guid>()
                    {
                        UserId = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                        RoleId = new Guid("f5c38744-072b-4785-9c6d-db48ac043b7f")
                    }
                );
        }

        public static void SeedUserEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasData(
                    new UserEntity()
                    {
                        Id = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187"),
                        FirstName = "Ana",
                        LastName = "Mklavashvili",
                        Email = "anamklavashvili@gmail.com",
                        NormalizedEmail = "ANAMKLAVASHVILI@GMAIL.COM",
                        UserName = "ana",
                        PasswordHash = HashPassword("ana1234"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    },
                    new UserEntity()
                    {
                        Id = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                        FirstName = "Sandro",
                        LastName = "Revazishvili",
                        Email = "sandro.revazishviliii@gmail.com",
                        NormalizedEmail = "SANDRO.REVAZISHVILIII@GMAIL.COM",
                        UserName = "sandro",
                        PasswordHash = HashPassword("sandro1234"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                );
        }

        public static void SeedAccountEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .HasData(
                    new AccountEntity
                    {
                        Id = new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                        Amount = new Random().Next(10000, 20000),
                        Iban = "Ana's Iban",
                        UserId = new Guid("4bf7d82a-fca9-4d1d-bbc9-48cfaa109187")
                    },
                    new AccountEntity
                    {
                        Id = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                        Amount = new Random().Next(10000, 20000),
                        Iban = "Sandro's Iban",
                        UserId = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4")
                    }
                );
        }

        public static void SeedCardEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardEntity>()
                .HasData(
                    new CardEntity()
                    {
                        Id = new Guid("62e5f726-6070-4326-9a25-c27c6216e35f"),
                        AccountId = new Guid("1ffae49b-5579-4560-bf20-fd3986fd76c0"),
                        Cvv = "931",
                        Pin = "1234",
                        FullName = "Ana Mklavashvili"
                    },
                    new CardEntity()
                    {
                        Id = new Guid("d38dc493-fb60-4d75-8930-48dee7dc3f97"),
                        AccountId = new Guid("7b1902d5-c240-49f4-b91f-454d9e19d402"),
                        Cvv = "931",
                        Pin = "1234",
                        FullName = "Sandro Revazishvili"
                    }
                );
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}