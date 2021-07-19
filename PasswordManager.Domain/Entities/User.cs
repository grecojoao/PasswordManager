namespace PasswordManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}