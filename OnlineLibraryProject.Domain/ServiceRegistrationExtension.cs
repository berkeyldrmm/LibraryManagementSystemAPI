using OnlineLibraryProject.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpOptions>(configuration.GetSection("Smtp"));
            services.Configure<RegisterEmailOptions>(configuration.GetSection("RegisterEmailOptions"));
            services.Configure<ConfirmationEmailOptions>(configuration.GetSection("ConfirmationEmailOptions"));
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

            return services;
        }
    }
}
