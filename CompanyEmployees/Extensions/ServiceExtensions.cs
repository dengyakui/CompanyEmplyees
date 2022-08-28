using Contracts;
using LoggerService;
using Repository;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection serviceCollection) =>
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            });
        });


    public static void ConfigureIISIntegration(this IServiceCollection serviceCollection)
    {
        serviceCollection.Configure<IISOptions>(options =>
        {

        });
    }

    public static void ConfigureLoggerService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfiureRepositoryManager(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
}