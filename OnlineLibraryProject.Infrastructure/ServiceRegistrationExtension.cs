using OnlineLibraryProject.Application.Abstraction;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Infrastructure.Authentication;
using OnlineLibraryProject.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibraryProject.Infrastructure;

public static class ServiceRegistrationExtension
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IMailService, MailService>();

        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
