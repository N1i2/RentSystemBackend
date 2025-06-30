using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Review() { }

        public static Review Create(
            Guid userId,
            Guid roomId,
            int rating,
            string comment)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainException(nameof(userId));
            }
            if (roomId == Guid.Empty)
            {
                throw new DomainException(nameof(roomId));
            }
            if (rating is < 1 or > 5)
            {
                throw new DomainException(nameof(rating));
            }
            if (string.IsNullOrWhiteSpace(comment))
            {
                throw new DomainException(nameof(comment));
            }

            return new Review
            {
                UserId = userId,
                RoomId = roomId,
                Rating = rating,
                Comment = comment,
                CreatedAt = DateTime.Now
            };
        }
    }
}
