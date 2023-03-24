using System.Security.Claims;
using System.Text;
using BankSystem.Common.Auth;
using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BankSystem.InternetBank.Api.Auth;

public static class AuthConfigurator
{
    public static void Configure(WebApplicationBuilder builder)
    {
        var issuer = builder.Configuration["Jwt:Issuer"]!;
        var audience = builder.Configuration["Jwt:Audience"]!;
        var key = builder.Configuration["Jwt:SecretKey"]!;
        builder.Services.Configure<JwtSettings>(s =>
        {
            s.Issuer = issuer;
            s.Audience = audience;
            s.SecrectKey = key;  
        });
        builder.Services.AddTransient<TokenGenerator>();

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiUser",
                policy => policy.RequireClaim(ClaimTypes.Role, "api-user"));
    
            options.AddPolicy("ApiOperator",
                policy => policy.RequireClaim(ClaimTypes.Role, "api-operator"));
        });
        builder.Services
            .AddIdentity<UserEntity, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 2;
            })
            .AddEntityFrameworkStores<BankSystemDbContext>()
            .AddDefaultTokenProviders();
        
    }
}