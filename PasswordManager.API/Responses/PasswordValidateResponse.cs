namespace PasswordManager.API.Responses
{
    public class PasswordValidateResponse
    {
        public bool IsPasswordValid { get; set; }

        public PasswordValidateResponse(bool isPasswordValid)
        {
            IsPasswordValid = isPasswordValid;
        }
    }
}