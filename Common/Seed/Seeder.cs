using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Security.Cryptography;

namespace BankSystem.Common.Seed
{
    public static class Seeder
    {
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
                        UserName = "ana",
                        PasswordHash = HashPassword("ana1234"),
                    },
                    new UserEntity()
                    {
                        Id = new Guid("0eb288d0-c7cd-4749-ad29-92a9d59e8bf4"),
                        FirstName = "Sandro",
                        LastName = "Revazishvili",
                        Email = "sandro.revazishviliii@gmail.com",
                        UserName = "sandro",
                        PasswordHash = HashPassword("sandro1234"),
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
