using System;

namespace PasswordManager.API.Responses
{
    public class LoginResponse
    {
        public string User { get; set; }
        public bool Authenticated { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpirationDate { get; set; }

        public LoginResponse(string userName, bool authenticated, string tokenValue, DateTime? tokenExpirationDate)
        {
            User = userName;
            Authenticated = authenticated;
            Token = tokenValue;
            TokenExpirationDate = tokenExpirationDate;
        }
    }
}