using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NXCare.Domain.Interfaces.Services;
using NXCare.Domain.Options.Auth;
using NXCare.Mock.Services;

namespace NXCare.API.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddNXCareDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwt(configuration);
            services.AddServices(configuration);
            services.AddNXCareOptions(configuration);
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(cfg => cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer           = true,
                        ValidateAudience         = true,
                        ValidateLifetime         = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer              = configuration["Jwt:Issuer"],
                        ValidAudience            = configuration["Jwt:Audience"],
                        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
                    };
                });
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationService, MockAuthenticationService>();
        }

        public static void AddNXCareOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        }
    }
}