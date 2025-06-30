using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class ImageRoom : BaseEntity
    {
        public Guid RoomPropertyId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int SortOrder { get; set; }

        private ImageRoom() { }

        public static ImageRoom Create(
            Guid roomPropertyId,
            string imageUrl,
            bool isMain = false,
            int sortOrder = 0)
        {
            if (roomPropertyId == Guid.Empty)
            {
                throw new DomainException("Incorrect room property Id.");
            }
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                throw new DomainException("Image URL cannot be empty.");
            }
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                throw new DomainException("Invalid image URL format.");
            }
            if (sortOrder < 0)
            {
                throw new DomainException("Sort order cannot be negative.");
            }

            return new ImageRoom
            {
                RoomPropertyId = roomPropertyId,
                ImageUrl = imageUrl,
                IsMain = isMain,
                SortOrder = sortOrder
            };
        }
    }
}
