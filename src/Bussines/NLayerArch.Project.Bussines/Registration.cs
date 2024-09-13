using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Abstract.Base;
using NLayerArch.Project.DataAccess.Repositories.Concrete;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.DataAccess.UnitOfWorks;
using System.Reflection;

namespace NLayerArch.Project.Bussines
{
    public static class Registration
    {
        public static IServiceCollection AddDataLayerDPIs(this IServiceCollection services , IConfiguration configration)
        {
            // Add DbContext with connection string from appsettings.json
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRoleOperationClaimRepository, RoleOperationClaimRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISponsorshipRepository, SponsorshipRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            return services;
        }

        public static IServiceCollection AddBussinesLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddHttpContextAccessor();
            services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
                  Assembly assembly,
                  Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var t in types)
            {
                services.AddTransient(t);
            }
            return services;
        }
    }
}
