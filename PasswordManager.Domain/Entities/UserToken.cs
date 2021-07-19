using System;

namespace PasswordManager.Domain.Entities
{
    public class UserToken
    {
        public string UserName { get; private set; }
        public bool Authenticated { get; private set; }
        public string TokenValue { get; private set; }
        public DateTime? TokenExpirationDate { get; private set; }

        public UserToken(
            string userName, bool authenticated, string tokenValue = null, DateTime? tokenExpirationDate = null)
        {
            UserName = userName;
            Authenticated = authenticated;
            TokenValue = tokenValue;
            TokenExpirationDate = tokenExpirationDate;
        }
    }
}