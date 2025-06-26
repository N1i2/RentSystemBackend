using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        private Booking() { }

        public static Booking Create(
            Guid userId,
            decimal totalPrice
        )
        {
            if (userId == Guid.Empty)
            {
                throw new DomainException("Incorrect user Id.");
            }
            if (totalPrice < 0)
            {
                throw new DomainException("Incorrect total price.");
            }

            return new Booking
            {
                UserId = userId,
                Status = BookingStatusName.Pending,
                TotalPrice = totalPrice
            };
        }
    }
}
