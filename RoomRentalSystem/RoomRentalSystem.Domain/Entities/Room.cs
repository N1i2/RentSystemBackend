using System.Security.AccessControl;
using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Room : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public string Title { get; private set; }
        public decimal PricePerDay { get; private set; }
        public string Description { get; private set; }
        public int Floor { get; private set; }
        public double Area { get; private set; }
        public int RoomCount { get; private set; }
        public string Amenities { get; private set; }
        public string Address { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<RoomImage> Images { get; private set; } = [];
        public ICollection<Booking> Bookings { get; private set; } = [];
        public ICollection<Review> Reviews { get; set; } = [];

        private Room() { }
        
        public static Room Create(
            Guid userId,
            string title,
            decimal pricePerDay,
            string description,
            int floor,
            double area,
            int roomCount,
            string address,
            string amenities = "")
        {
            if (userId == Guid.Empty)
            {
                throw new DomainException(nameof(userId));
            }
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException(nameof(title));
            }
            if (pricePerDay < 0)
            {
                throw new DomainException(nameof(pricePerDay));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException(nameof(description));
            }
            if (floor <= 0)
            {
                throw new DomainException(nameof(floor));
            }
            if (area <= 0)
            {
                throw new DomainException(nameof(area));
            }
            if (roomCount <= 0)
            {
                throw new DomainException(nameof(roomCount));
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException(nameof(address));
            }

            return new Room
            {
                UserId = userId,
                Title = title,
                PricePerDay = pricePerDay,
                Description = description,
                Floor = floor,
                Area = area,
                RoomCount = roomCount,
                Amenities = amenities,
                Address = address,
                IsActive = true
            };
        }
    }
}
