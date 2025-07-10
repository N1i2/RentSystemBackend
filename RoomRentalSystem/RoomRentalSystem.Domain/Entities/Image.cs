using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageData { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        private Image() { }

        public static Image Create(
            string imageData,
            string name,
            string type)
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

            return new Image
            {
                ImageData = imageData,
                Name = name,
                Type = type
            };
        }
    }
}
