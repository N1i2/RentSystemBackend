using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(r => r.Floor)
                .IsRequired();

            builder.Property(r => r.Area)
                .IsRequired();

            builder.Property(r => r.RoomCount)
                .IsRequired();

            builder.Property(r => r.Amenities)
                .HasMaxLength(1000);

            builder.Property(r => r.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(r => r.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(r => r.Images)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId);

            builder.HasMany(r => r.Reviews)
                .WithOne(r => r.Room)
                .HasForeignKey(r => r.RoomId);

            builder.HasIndex(r => r.UserId);
        }
    }
}
