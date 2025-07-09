using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageData { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid? RoomId { get; private set; }
        public Room? Room { get; private set; }
        public Guid? UserId { get; private set; }
        public User? User { get; private set; }

        private Image() { }

        public static Image Create(
            string imageData,
            string name,
            string type,
            Guid? roomId,
            Guid? userId)
        {
            if (string.IsNullOrWhiteSpace(imageData))
            {
                throw new DomainException(nameof(imageData));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new DomainException(nameof(type));
            }
            if ((roomId != null && userId != null) ||
                (roomId == null && userId == null))
            {
                throw new DomainException(nameof(userId) + " or " + nameof(roomId));
            }

            return new Image
            {
                ImageData = imageData,
                Name = name,
                Type = type,
                RoomId = roomId,
                UserId = userId
            };
        }
    }
}
