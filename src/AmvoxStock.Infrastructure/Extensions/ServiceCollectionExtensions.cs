using AmovoxStock.Application.Common.Persistence;
using AmvoxStock.Infrastructure.Caching;
using AmovoxStock.Infrastructure.Persistence.Context;
using AmvoxStock.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmovoxStock.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        return services
            .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
            .AddRepositories()
            .AddCaching(configuration);
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

    private static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration config)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "";
            options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
            {
                AbortOnConnectFail = true,
                EndPoints = { "" },
                Password = ""
            };
        });

        services.AddTransient<ICacheService, DistributedCacheService>();

        return services;
    }
}