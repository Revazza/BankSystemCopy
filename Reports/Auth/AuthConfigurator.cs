using System.Security.Claims;
using System.Text;
using CommonServices.Auth;
using CommonServices.Db;
using CommonServices.Db.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace InternetBank.API.Auth;

public static class AuthConfigurator
{
    public static void Configure(WebApplicationBuilder builder)
    {
        var issuer = builder.Configuration["Jwt:Issuer"]!;
        var audience = builder.Configuration["Jwt:Audience"]!;
        var key = builder.Configuration["Jwt:SecretKey"]!;

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
            options.AddPolicy("ApiAdmin",
                policy => policy.RequireClaim(ClaimTypes.Role, "api-admin"));
        });
        
    }
}