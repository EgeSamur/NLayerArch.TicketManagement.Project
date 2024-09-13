using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerArch.Project.DataAccess.Context;

namespace NLayerArch.Project.Bussines
{
    public static class Registration
    {
        public static IServiceCollection AddDPIs(this IServiceCollection services , IConfiguration configration)
        {
            // Add DbContext with connection string from appsettings.json
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
