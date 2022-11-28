using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Domain_Layer.Contracts;
using Sat.Recruitment.Api.Domain_Layer.DomainService;

namespace Sat.Recruitment.Api.Configuration
{
    public static class ServiceProviderExtensions
    {
        public static void AddServiceProviderExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
