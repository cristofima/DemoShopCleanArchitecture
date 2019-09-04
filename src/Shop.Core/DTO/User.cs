namespace Shop.Core.DTO
{
    public class User
    {
        public string Id { get; }
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get; }

        public User(string email, string userName, string id = null, string passwordHash = null)
        {
            Id = id;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}