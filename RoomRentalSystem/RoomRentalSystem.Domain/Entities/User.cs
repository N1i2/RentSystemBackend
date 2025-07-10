using RoomRentalSystem.Domain.Exception;
using RoomRentalSystem.Domain.ValidationRules;
using static System.Text.RegularExpressions.Regex;

namespace RoomRentalSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public Guid? ImageId { get; private set; }
        public Image? Image { get; private set; }
        public ICollection<Role> Roles { get; private set; } = [];
        public ICollection<Room> Rooms { get; private set; } = [];
        public ICollection<Review> Reviews { get; private set; } = [];
        public ICollection<Booking> Bookings { get; private set; } = [];

        private User() { }

        public static User? Create(
            string phoneNumber,
            string email,
            string passwordHash,
            ICollection<Role> roles)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new DomainException(nameof(phoneNumber));
            }
            if (!IsValidEmail(email))
            {
                throw new DomainException(nameof(email));
            }
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new DomainException(nameof(passwordHash));
            }

            var rolesArray = roles ?? [];
            if (!rolesArray.Any())
            {
                throw new DomainException(nameof(roles));
            }

            return new User
            {
                PasswordHash = passwordHash,
                PhoneNumber = phoneNumber,
                Email = email,
                Roles = rolesArray
            };
        }

        private static bool IsValidEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && IsMatch(email, RegularExpressionsForValidation.EmailValidationPattern);
        private static bool IsValidPhoneNumber(string phoneNumber) =>
            !string.IsNullOrWhiteSpace(phoneNumber) && IsMatch(phoneNumber, RegularExpressionsForValidation.BelarusPhoneNumberValidationPattern);
    }
}
