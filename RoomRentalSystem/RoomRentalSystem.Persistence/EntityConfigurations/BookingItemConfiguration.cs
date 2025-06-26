using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
    {
        public void Configure(EntityTypeBuilder<BookingItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoomPropertyId)
                .IsRequired();

            builder.Property(x => x.BookingId)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();

            builder.ToTable(b => b.HasCheckConstraint(
                "CK_BookingItem_StartDateNotInPast",
                "StartDate >= CAST(GETDATE() AS DATE)"));

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasAnnotation("CheckConstraint", "Price >= 0");

            builder.HasIndex(x => new { x.RoomPropertyId, x.StartDate, x.EndDate });
        }
    }
}
