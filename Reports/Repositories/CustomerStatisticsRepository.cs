using BankSystem.Common.Db;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Reports.Repositories;

public interface ICustomersStatisticsRepository
{
    Task<int> GetCustomersRegisteredThisYear();
    Task<int> GetCustomersRegisteredLast12Months();
    Task<int> GetCustomersRegisteredLast30Days();
}

public class CustomerStatisticsRepository : ICustomersStatisticsRepository
{
    private readonly BankSystemDbContext _context;

    public CustomerStatisticsRepository(BankSystemDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetCustomersRegisteredThisYear()
    { 
        var customersRegisteredThisYear = await _context.Users
            .Where(u => u.RegisteredAt.Year == DateTime.Now.Year)
            .CountAsync();
        return customersRegisteredThisYear;
    }

    public async Task<int> GetCustomersRegisteredLast12Months()
    {
        var customersRegisteredLast12Months = await _context.Users
            .Where(u => u.RegisteredAt >= DateTime.Now.AddMonths(-12))
            .CountAsync();
        return customersRegisteredLast12Months;
    }

    public async Task<int> GetCustomersRegisteredLast30Days()
    {
        var customersRegisteredLast30Days = await _context.Users
            .Where(u => u.RegisteredAt >= DateTime.Now.AddDays(-30))
            .CountAsync();
        return customersRegisteredLast30Days;
    }
}