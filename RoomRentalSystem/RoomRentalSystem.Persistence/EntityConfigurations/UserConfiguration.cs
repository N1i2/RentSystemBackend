using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomRentalSystem.Domain.Entities;
using RoomRentalSystem.Domain.ValidationRules;

namespace RoomRentalSystem.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasAnnotation("RegularExpression", RegularExpressionsForValidation.BelarusPhoneNumberValidationPattern);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasAnnotation("RegularExpression", RegularExpressionsForValidation.EmailValidationPattern);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));

            builder.HasMany(u => u.Rooms)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.HasMany(u => u.FavoriteRooms)
                .WithMany()
                .UsingEntity(j => j.ToTable("UserFavoriteRooms"));

            builder.HasMany(u => u.Comparisons)
                .WithMany()
                .UsingEntity(j => j.ToTable("UserRoomComparisons"));

            builder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);
        }
    }
}
