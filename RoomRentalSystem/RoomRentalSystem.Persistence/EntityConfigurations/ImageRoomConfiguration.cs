using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class ImageRoomConfiguration : IEntityTypeConfiguration<ImageRoom>
    {
        public void Configure(EntityTypeBuilder<ImageRoom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoomPropertyId)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsMain)
                .IsRequired();

            builder.Property(x => x.SortOrder)
                .IsRequired();

            builder.HasIndex(x => new { x.RoomPropertyId, x.SortOrder })
                .IsUnique();
        }
    }
}
