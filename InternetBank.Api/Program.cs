using CommonServices.Db;
using CommonServices.Db.Entities;
using CommonServices.Repositores;
using CommonServices.Seed;
using InternetBank.API.Auth;
using InternetBank.API.Requests;
using InternetBank.API.Validations;
using InternetBank.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var os = Environment.OSVersion.Platform.ToString().ToLower();
builder.Configuration.AddJsonFile($"appsettings.{os}.json", optional: true).Build();

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{os}.json", optional: true)
    .Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankSystemDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


AuthConfigurator.Configure(builder);

builder.Services.AddDbContext<BankSystemDbContext>(c =>
    c.UseSqlServer(builder.Configuration["DefaultConnection"]));
builder.Services.AddTransient<TransactionValidator>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddTransient<IbanService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOperatorRepository, OperatorRepository>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<RegisterCardValidator>();
builder.Services.AddTransient<IUserLoginService, UserLoginService>();
builder.Services.AddTransient<IAddAccountService, AddAccountService>();
builder.Services.AddTransient<IAddCardService, AddCardService>();
builder.Services.AddTransient<IAddUserService, AddUserService>();

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
