using CommonServices.Db;
using Microsoft.EntityFrameworkCore;

namespace InternetBank.Tests;

public class FakeBankSystemDbContext  : BankSystemDbContext
{
    public FakeBankSystemDbContext() : base(new DbContextOptionsBuilder<BankSystemDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDb")
        .Options)
    {
        
    }
}