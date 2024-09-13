using Microsoft.Extensions.DependencyInjection;
using NLayerArch.Project.Security.JWT;

namespace NLayerArch.Project.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            return services;
        }
    }
}
