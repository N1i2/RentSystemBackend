namespace RoomRentalSystem.Domain.Entities
{
    public class UserRole: BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }

        private UserRole(){ }

        public static UserRole Create(User user, Role role)
        {
            return new UserRole { User = user, Role = role};
        }
    }
}
