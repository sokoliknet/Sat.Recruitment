using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Configuration;
using Sat.Recruitment.Api.Mappings;
using System.Reflection;

namespace Sat.Recruitment.Api
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
           this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IConfiguration>(provider => config);
            services.AddServiceProviderExtensions();
            services.AddRepoProviderExtensions();
            services.AddAutoMapper(typeof(UserMapping).GetTypeInfo().Assembly);

            return services;
        }
    }
}
