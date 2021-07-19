namespace PasswordManager.API.Responses
{
    public class PasswordGenerateResponse
    {
        public string Password { get; set; }

        public PasswordGenerateResponse(string password)
        {
            Password = password;
        }
    }
}