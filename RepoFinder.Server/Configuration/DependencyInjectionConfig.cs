using RepoFinder.Api.Profiles;
using RepoFinder.Business.Interfaces;
using RepoFinder.Business.Services;
using RepoFinder.Infra.Services;

namespace RepoFinder.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGithubAPI, GithubAPI>();
            services.AddScoped<IGitHubService, GithubService>();
            services.AddHttpClient<IGithubAPI, GithubAPI>(c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("Github").GetValue<string>("ApiBaseURL") ?? "");
                c.DefaultRequestHeaders.Add("Accept", "application/json"); 
                c.DefaultRequestHeaders.Add("User-Agent", "RepoFinder"); 
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
