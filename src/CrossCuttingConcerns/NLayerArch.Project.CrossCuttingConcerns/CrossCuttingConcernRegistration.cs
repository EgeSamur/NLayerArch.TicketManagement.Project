using Microsoft.Extensions.DependencyInjection;
using NLayerArch.Project.CrossCuttingConcerns.Exceptions;

namespace NLayerArch.Project.CrossCuttingConcerns
{
    public static class CrossCuttingConcernRegistration
    {
        public static IServiceCollection AddCrossCuttingConcern(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }
    }
}
