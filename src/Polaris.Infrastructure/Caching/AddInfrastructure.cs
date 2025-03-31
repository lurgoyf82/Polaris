using Microsoft.Extensions.DependencyInjection;
using Polaris.Domain.Repositories;
using Polaris.Infrastructure.Persistence;
using StackExchange.Redis;

namespace Polaris.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // Register a Dapper database connection (example with PostgreSQL)
            services.AddScoped<IDbConnection>(_ => new Npgsql.NpgsqlConnection(connectionString));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerRepository>();

            // Configure Redis
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddSingleton<Caching.ICacheService, Caching.RedisCacheService>();

            // Register RabbitMQ Event Bus
            services.AddSingleton<Messaging.IEventBus, Messaging.RabbitMqEventBus>();

            // Additional configurations (Serilog, OpenTelemetry, etc.) can be added here.
            return services;
        }
    }
}
