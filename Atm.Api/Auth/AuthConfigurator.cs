using BankSystem.Common.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ATM.Api.Auth
{
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

        }

    }
}
