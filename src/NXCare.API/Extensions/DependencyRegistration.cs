using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NXCare.API.Services;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.NXCare;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using NXCare.Domain.Interfaces.Services;
using NXCare.Mappers;
using NXCare.Services.Addresses;
using NXCare.Services.Patients;

namespace NXCare.API.Extensions
{
    public static class DependencyRegistration
    {
        public static void RegisterNXCareDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.RegisterServices(configuration);
            services.RegisterMappers(configuration);
        }

        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Contexts
            services.AddDbContext<NXCareContext>(options => options.UseSqlServer(configuration.GetConnectionString("NXCare")));

            // Register repositories in a scoped life time
            services.AddScoped<IPatientRepository       , PatientRepository>();
            services.AddScoped<ILanguageRepository      , LanguageRepository>();
            services.AddScoped<IAddressRepository       , AddressRepository>();
            services.AddScoped<ICountryRepository       , CountryRepository>();
            services.AddScoped<IPhysicianRepository     , PhysicianRepository>();
            services.AddScoped<ITransitionRepository    , TransitionRepository>();
            services.AddScoped<IVisitRepository         , VisitRepository>();
            services.AddScoped<IPatientAddressRepository, PatientAddressRepository>();
        }

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAddressService       , AddressService>();
            services.AddScoped<IPatientCreationService  , PatientCreationService>();
        }

        public static void RegisterMappers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddressMapper , AddressMapper>();
            services.AddScoped<ICountryMapper , CountryMapper>();
            services.AddScoped<ILanguageMapper, LanguageMapper>();
            services.AddScoped<IPatientMapper , PatientMapper>();
        }
    }
}