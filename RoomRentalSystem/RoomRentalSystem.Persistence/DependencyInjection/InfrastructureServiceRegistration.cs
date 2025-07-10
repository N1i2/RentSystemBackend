using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.DependencyInjection
{
    public class InfrastructureServiceRegistration(DbContextOptions<InfrastructureServiceRegistration> options)
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Image> RoomImages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                Role.Create(Guid.Parse("11111111-1111-1111-1111-111111111111"), RoleNames.Admin),
                Role.Create(Guid.Parse("22222222-2222-2222-2222-222222222222"), RoleNames.Guest),
                Role.Create(Guid.Parse("33333333-3333-3333-3333-333333333333"), RoleNames.Owner)
            );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureServiceRegistration).Assembly);
        }
    }
}