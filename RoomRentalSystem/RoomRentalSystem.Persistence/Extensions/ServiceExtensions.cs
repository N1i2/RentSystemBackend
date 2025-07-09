using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.IRepositories;
using RoomRentalSystem.Persistence.DependencyInjection;
using RoomRentalSystem.Persistence.Repositories;

namespace RoomRentalSystem.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<InfrastructureServiceRegistration>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}