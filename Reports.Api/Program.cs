using BankSystem.Common.Db;
using InternetBank.API.Auth;
using Microsoft.EntityFrameworkCore;
using BankSystem.Reports.API.Auth;
using BankSystem.Reports.Repositories;
using BankSystem.Reports.Services;

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

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICustomersStatisticsRepository, CustomerStatisticsRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
