using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Comparison : BaseEntity
    {
        public Guid RoomPropertyId { get; set; }
        public Guid UserId { get; set; }

        private Comparison() { }

        public static Comparison Create(
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

            return new Comparison
            {
                RoomPropertyId = roomPropertyId,
                UserId = userId
            };
        }
    }
}
