namespace PasswordValidator.Api.Models
{
    public class PasswordResponse
    {
        public bool IsValid { get; set; }

        public static PasswordResponse FromBool(bool isValid)
        {
            return new PasswordResponse
            {
                IsValid = isValid
            };
        }
    }
}
