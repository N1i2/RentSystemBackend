using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Exception;
using static System.Text.RegularExpressions.Regex;

namespace RoomRentalSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }

        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public List<UserRole> UserRoles { get; private set; } = [];

        public static User Create(
            string phoneNumber,
            string email,
            string passwordHash)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new DomainException("Incorrect phone number");
            }
            if (!IsValidEmail(email))
            {
                throw new DomainException("Incorrect email");
            }
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new DomainException("Incorrect password");
            }

            return new User
            {
                PasswordHash = passwordHash,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        public void AddRole(Role role)
        {
            if (role == null)
            {
                throw new DomainException("Incorrect role");
            }

            UserRoles.Add(UserRole.Create(this, role));
        }

        private static bool IsValidEmail(string email) => 
            !(string.IsNullOrWhiteSpace(email)) && (IsMatch(email, RegexPatterns.Email));
        private static bool IsValidPhoneNumber(string phoneNumber) =>
            !(string.IsNullOrWhiteSpace(phoneNumber)) && (IsMatch(phoneNumber, RegexPatterns.PhoneNumber));
    }
}
