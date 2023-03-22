using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankSystem.Common.Db;
    
public class BankSystemDbContextFactory : IDesignTimeDbContextFactory<BankSystemDbContext>
{
    public BankSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BankSystemDbContext>();
        optionsBuilder.UseSqlServer(args[0]);
        
        return new BankSystemDbContext(optionsBuilder.Options);
    }
}