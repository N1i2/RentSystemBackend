using Microsoft.EntityFrameworkCore;
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureServiceRegistration).Assembly);
        }
    }
}