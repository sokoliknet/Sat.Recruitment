using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Data_Access_Layer.Contracts;
using Sat.Recruitment.Api.Data_Access_Layer.Repositories;

namespace Sat.Recruitment.Api.Configuration
{
    public static class RepoProviderExtensions
    {
        public static void AddRepoProviderExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
