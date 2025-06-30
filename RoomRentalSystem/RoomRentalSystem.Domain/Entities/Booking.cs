using RoomRentalSystem.Domain.Constants;
using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public RoomRentalStatus Status { get; private set; }

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
            if ((startDate >= endDate) ||
                ((endDate - startDate).TotalDays > 365) ||
                (startDate.Date < DateTime.UtcNow.Date) ||
                ((endDate - startDate).TotalDays <= 1))
            {
                throw new DomainException(nameof(startDate) + ' ' + nameof(endDate));
            }
            if (totalPrice < 0)
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
                Status = RoomRentalStatus.Pending
            };
        }
    }
}
