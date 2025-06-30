using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Role : BaseEntity
    {
        public ICollection<User> Users { get; private set; }
        public string Name { get; private set; }

        private Role() { }

        public static Role Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(nameof(name));
            }

            return new Role
            {
                Name = name
            };
        }
    }
}
