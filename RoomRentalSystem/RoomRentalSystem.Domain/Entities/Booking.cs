using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }

        private const int MaxRentalDay = 365;
        private const int MinRentalDay = 1;
        private const decimal MinTotalPrice = 1;

        private Booking() { }

        public static Booking Create(
            Guid userId,
            Guid roomId,
            DateTime startDate,
            DateTime endDate,
            decimal totalPrice
        )
        {
            if (userId == Guid.Empty)
            {
                throw new DomainException(nameof(userId));
            }
            if (roomId == Guid.Empty)
            {
                throw new DomainException(nameof(roomId));
            }
            if (startDate >= endDate ||
                (endDate - startDate).TotalDays > MaxRentalDay ||
                startDate.Date < DateTime.UtcNow.Date ||
                (endDate - startDate).TotalDays <= MinRentalDay)
            {
                throw new DomainException(nameof(startDate) + ' ' + nameof(endDate));
            }
            if (totalPrice < MinTotalPrice)
            {
                throw new DomainException(nameof(totalPrice));
            }

            return new Booking
            {
                UserId = userId,
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
            };
        }
    }
}
