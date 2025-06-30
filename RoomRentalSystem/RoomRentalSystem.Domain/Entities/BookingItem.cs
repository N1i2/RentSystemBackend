using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class BookingItem : BaseEntity
    {
        public Guid RoomPropertyId { get; set; }
        public Guid BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        private BookingItem() { }

        public static BookingItem Create(
            Guid roomPropertyId,
            Guid bookingId,
            DateTime startDate,
            DateTime endDate,
            decimal price)
        {
            if (roomPropertyId == Guid.Empty)
            {
                throw new DomainException("Incorrect room property Id.");
            }
            if (bookingId == Guid.Empty)
            {
                throw new DomainException("Incorrect booking Id.");
            }
            if (startDate == DateTime.MinValue || startDate == DateTime.MaxValue)
            {
                throw new DomainException("Incorrect start date.");
            }
            if (endDate == DateTime.MinValue || endDate == DateTime.MaxValue)
            {
                throw new DomainException("Incorrect end date.");
            }
            if ((startDate >= endDate) &&
                ((endDate - startDate).TotalDays > 365) &&
                (startDate.Date < DateTime.UtcNow.Date))
            {
                throw new DomainException("Incorrect booking date.");
            }
            if (price < 0)
            {
                throw new DomainException("Incorrect price.");
            }

            return new BookingItem
            {
                RoomPropertyId = roomPropertyId,
                BookingId = bookingId,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };
        }
    }
}
