using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class RoomImage : BaseEntity
    {
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsMain { get; private set; }
        public int SortOrder { get; private set; }

        private RoomImage() { }

        public static RoomImage Create(
            Guid roomId,
            string imageUrl,
            bool isMain = false,
            int sortOrder = 0)
        {
            if (roomId == Guid.Empty)
            {
                throw new DomainException(nameof(roomId));
            }
            if (string.IsNullOrWhiteSpace(imageUrl) || 
                !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                throw new DomainException(nameof(imageUrl));
            }
            if (sortOrder < 0)
            {
                throw new DomainException(nameof(sortOrder));
            }

            return new RoomImage
            {
                RoomId = roomId,
                ImageUrl = imageUrl,
                IsMain = isMain,
                SortOrder = sortOrder
            };
        }
    }
}
