using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public Guid RoomPropertyId { get; set; }
        public Guid UserId { get; set; }

        private Favorite() { }

        public static Favorite Create(
            Guid roomPropertyId,
            Guid userId)
        {
            if (roomPropertyId == Guid.Empty)
            {
                throw new DomainException("Incorrect room property Id.");
            }
            if (userId == Guid.Empty)
            {
                throw new DomainException("Incorrect user Id.");
            }

            return new Favorite
            {
                RoomPropertyId = roomPropertyId,
                UserId = userId
            };
        }
    }
}
