using BankSystem.Common.Db.Entities;
using BankSystem.Common.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Common.Db;

public class BankSystemDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
{
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<CardEntity> Cards { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<OperatorEntity> Operators { get; set; }
    public DbSet<CurrencyEntity> Currencies { get; set; }
    public DbSet<EmailRequestEntity> EmailRequests { get; set; }

    public BankSystemDbContext(DbContextOptions<BankSystemDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.Accounts)
            .WithOne(a => a.UserEntity)
            .HasForeignKey(u => u.UserId);
        modelBuilder.Entity<AccountEntity>()
            .HasMany(c => c.Cards)
            .WithOne(a => a.Account)
            .HasForeignKey(a => a.AccountId);

        modelBuilder.Entity<OperatorEntity>()
            .HasData(new OperatorEntity()
            {
                Name = "ana",
                Id = new Guid("8f5f5990-2d11-455f-8b40-5767c7a5545d")
            });

        modelBuilder.SeedUserEntity();
        modelBuilder.SeedAccountEntity();
        modelBuilder.SeedCardEntity();
        

        base.OnModelCreating(modelBuilder);
    }



}


