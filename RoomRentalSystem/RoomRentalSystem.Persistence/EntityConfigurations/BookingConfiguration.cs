using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        private const int MaxRentalDays = 365;
        private const int MinRentalDays = 1;
        private const decimal MinTotalPrice = 1;

        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.StartDate)
                .IsRequired();

            builder.Property(b => b.EndDate)
                .IsRequired();

            builder.Property(b => b.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasAnnotation("MinValue", MinTotalPrice);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(b => b.HasCheckConstraint(
                "CK_Booking_Dates",
                $"[EndDate] > [StartDate] AND DATEDIFF(day, [StartDate], [EndDate]) <= {MaxRentalDays} AND DATEDIFF(day, [StartDate], [EndDate]) >= {MinRentalDays}"));

            builder.ToTable(b => b.HasCheckConstraint(
                "CK_Booking_TotalPrice",
                $"[TotalPrice] >= {MinTotalPrice}"));

            builder.ToTable("Bookings");
        }
    }
}