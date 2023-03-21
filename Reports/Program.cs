using CommonServices.Db;
using InternetBank.API.Auth;
using Microsoft.EntityFrameworkCore;
using Reports.API.Auth;
using Reports.Repositories;
using Reports.Services.Transaction;

var builder = WebApplication.CreateBuilder(args);

var os = Environment.OSVersion.Platform.ToString().ToLower();
builder.Configuration.AddJsonFile($"appsettings.{os}.json", optional: true).Build();

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{os}.json", optional: true)
    .Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
SwaggerConfigurator.Configure(builder);

builder.Services.AddDbContext<BankSystemDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

AuthConfigurator.Configure(builder);

builder.Services.AddTransient<ITransactionStatisticsService, TransactionStatisticsService>();

builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ICustomersStatisticsRepository, CustomerStatisticsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
