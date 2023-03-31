using Microsoft.EntityFrameworkCore;

namespace Atm.Tests;
using BankSystem.Common.Db;
public class FakeBankSystemDbContext : BankSystemDbContext
{
    public FakeBankSystemDbContext() : base(new DbContextOptionsBuilder<BankSystemDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDb")
        .Options)
    {
        
    }
}