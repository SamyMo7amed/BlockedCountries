using BlocedCountriesApi.Models;
using BlocedCountriesApi.Repositories.AbstractRepositories;
using BlocedCountriesApi.Repositories.ImplementRepositories;
using BlocedCountriesApi.Services.AbstractServices;
using BlocedCountriesApi.Services.ImplemntServices;
using BlockedCountriesApi.Bases.Behavior;
using MediatR;
using System.Reflection;

namespace BlocedCountriesApi.Dependency
{
    public static class Dependencies
    {


        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddSingleton<MemoryStore>();
            services.AddSingleton<BackgroundService>();
            services.AddTransient<ICountryRepository,CountryRepository>();
            services.AddTransient<ILogRepository,LogRepository>();
            services.AddTransient<ITemporaryBlock,TemporaryBlockRepository>();
            services.AddTransient<ICountryService,CountryService>();
            services.AddTransient<ILogService,LogService>();
            services.AddTransient<ITemporaryBlockService,TemporaryBlockService>();
            services.AddHttpClient<IIpLookupService, IpLookupService>();









            return services;
        }
    }
}
