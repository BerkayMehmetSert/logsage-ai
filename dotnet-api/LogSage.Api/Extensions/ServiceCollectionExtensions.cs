using LogSage.Api.Application.Interfaces;
using LogSage.Api.Application.Services;
using LogSage.Api.Infrastructure.HttpClients;

namespace LogSage.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ILogAnalysisService, LogAnalysisService>();
        services.AddScoped<IPythonAgentClient, PythonAgentClient>();

        services.AddHttpClient<IPythonAgentClient, PythonAgentClient>(client =>
        {
            var baseUrl = config["PythonAgent:BaseUrl"];
            client.BaseAddress = new Uri(baseUrl!);
        });

        return services;
    }
}