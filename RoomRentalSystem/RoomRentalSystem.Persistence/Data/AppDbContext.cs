using System.Globalization;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Persistence.EntityConfigurations;

namespace RoomRentalSystem.Persistence.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, DbSet<RoomProperty> roomPropertys) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoomProperty> RoomProperties { get; set; } 
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<ImageRoom> ImageRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImageRoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoomPropertyConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new ComparisonConfiguration());
            modelBuilder.ApplyConfiguration(new BookingItemConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
        }
    }
}
