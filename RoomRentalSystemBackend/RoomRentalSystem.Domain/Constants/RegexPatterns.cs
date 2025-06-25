namespace RoomRentalSystem.Domain.Constants
{
    public static class RegexPatterns
    {
        public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public const string PhoneNumber = @"^\+375\s?(17|25|29|33|44)\d{3}-?\d{2}-?\d{2}$";
    }
}
