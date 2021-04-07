namespace PasswordValidator.Core.Constants
{
    public static class RegexPatternsConstants
    {
        public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[-!@#$%^&*()+])(?!.*(.+).*\1)[A-Za-z\d-!@#$%^&*()+]{9,}$";
    }
}
