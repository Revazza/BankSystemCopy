using ATM.Api.Auth;
using ATM.Api.Middlewares;
using BankSystem.Atm.Repositories;
using BankSystem.Atm.Services;
using BankSystem.Common.Db;
using BankSystem.Common.Repositores;
using Microsoft.EntityFrameworkCore;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("exception_logs/atm.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var os = Environment.OSVersion.Platform.ToString().ToLower();
builder.Configuration.AddJsonFile($"appsettings.{os}.json", optional: true).Build();

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{os}.json", optional: true)
    .Build();

builder.Host.UseSerilog();

builder.Services.AddDbContext<BankSystemDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

AuthConfigurator.Configure(builder);

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddTransient<ICashOutService, CashoutService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IChangePinService, ChangePinService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IEmailRequestRepository, EmailRequestRepository>();

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

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
