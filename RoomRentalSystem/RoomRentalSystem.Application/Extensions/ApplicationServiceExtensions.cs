using Microsoft.Extensions.DependencyInjection;
using RoomRentalSystem.Application.Services.Interfaces;
using RoomRentalSystem.Application.Services;
using RoomRentalSystem.Domain.IRepositories;
using RoomRentalSystem.Persistence.Repositories;

namespace RoomRentalSystem.Persistence.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}