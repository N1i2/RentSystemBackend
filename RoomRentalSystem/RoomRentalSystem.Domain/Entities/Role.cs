using RoomRentalSystem.Domain.Exception;

namespace RoomRentalSystem.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

        private Role() { }

        public static Role Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Role name cannot be empty.");
            }

            return new Role { Name = name };
        }
    }
}
