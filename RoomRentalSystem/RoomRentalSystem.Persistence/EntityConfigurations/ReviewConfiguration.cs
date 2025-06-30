using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomRentalSystem.Domain.Entities;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.HasIndex(r => r.UserId);
            builder.HasIndex(r => r.RoomId);

            builder.ToTable(b => b.HasCheckConstraint(
                "CK_Review_Rating",
                @"""Rating"" >= 1 AND ""Rating"" <= 5"));
        }
    }
}