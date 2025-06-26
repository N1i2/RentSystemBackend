using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class RoomPropertyConfiguration : IEntityTypeConfiguration<RoomProperty>
    {
        public void Configure(EntityTypeBuilder<RoomProperty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OwnerId)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Description)
                .IsRequired();
            builder.Property(x => x.Floor)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "Floor > 0");

            builder.Property(x => x.Area)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "Area > 0");

            builder.Property(x => x.CountOfRoom)
                .IsRequired()
                .HasAnnotation("CheckConstraint", "CountOfRoom > 0");

            builder.Property(x => x.Amenities)
                .HasMaxLength(1000);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
