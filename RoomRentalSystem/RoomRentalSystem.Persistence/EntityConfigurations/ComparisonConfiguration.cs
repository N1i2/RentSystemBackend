using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class ComparisonConfiguration : IEntityTypeConfiguration<Comparison>
    {
        public void Configure(EntityTypeBuilder<Comparison> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoomPropertyId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasIndex(x => new { x.UserId, x.RoomPropertyId })
                .IsUnique();
        }
    }
}
