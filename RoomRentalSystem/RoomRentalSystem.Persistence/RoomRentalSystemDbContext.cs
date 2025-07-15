using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence;

public class RoomRentalSystemDbContext(DbContextOptions<RoomRentalSystemDbContext> options)
    : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<ImageEntity> RoomImages { get; set; }
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
}