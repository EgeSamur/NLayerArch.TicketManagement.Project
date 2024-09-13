using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Abstract.Base;
using NLayerArch.Project.DataAccess.Repositories.Concrete;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.DataAccess.UnitOfWorks;

namespace NLayerArch.Project.Bussines
{
    public static class Registration
    {
        public static IServiceCollection AddDPIs(this IServiceCollection services , IConfiguration configration)
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


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
