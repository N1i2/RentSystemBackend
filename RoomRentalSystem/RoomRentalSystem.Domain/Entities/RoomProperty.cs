using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class RoomProperty : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public int CountOfRoom { get; set; }
        public string Amenities { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        private RoomProperty() { }

        public static RoomProperty Create(
            Guid ownerId,
            string title,
            decimal price,
            string description,
            int floor,
            double area,
            int countOfRoom,
            string amenities,
            string address)
        {
            if (ownerId == Guid.Empty)
            {
                throw new DomainException("Incorrect owner Id.");
            }
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Incorrect title.");
            }
            if (price < 0)
            {
                throw new DomainException("Incorrect price.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("Incorrect description.");
            }
            if (floor <= 0)
            {
                throw new DomainException("Incorrect floor.");
            }
            if (area <= 0)
            {
                throw new DomainException("Incorrect area.");
            }
            if (countOfRoom <= 0)
            {
                throw new DomainException("Incorrect count of room.");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException("Incorrect address.");
            }

            return new RoomProperty
            {
                OwnerId = ownerId,
                Title = title,
                Price = price,
                Description = description,
                Floor = floor,
                Area = area,
                CountOfRoom = countOfRoom,
                Amenities = amenities,
                Address = address,
                IsActive = true
            };
        }
    }
}
