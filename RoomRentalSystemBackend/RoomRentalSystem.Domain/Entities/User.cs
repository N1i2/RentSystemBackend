using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }

        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Role { get; private set; }

        public static User Create(
            string phoneNumber,
            string email,
            string passwordHash)
        {
            if (IsValidPhoneNumber(phoneNumber)) throw new DomainException("Incorrect phone number");
            if (IsValidEmail(email)) throw new DomainException("Incorrect email");
            if (string.IsNullOrWhiteSpace(passwordHash)) throw new DomainException("Incorrect password");

            return new User
            {
                PasswordHash = passwordHash,
                PhoneNumber = phoneNumber,
                Email = email,
                Role = RoleNames.Guest
            };
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            const string pattern = @"^\+\d{10,15}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
