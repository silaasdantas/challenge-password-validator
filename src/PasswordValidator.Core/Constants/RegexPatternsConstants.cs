namespace PasswordValidator.Core.Constants
{
    public static class RegexPatternsConstants
    {
        public const string PASSWORD_PATTERN = @"^(?=.*[a-zà-ú])(?=.*[A-ZÀ-Ú])(?=.*\d)(?=.*[-!@#$%^&*()+])(?!.*(.+).*\1)[A-ZÀ-Úa-zà-ú\d-!@#$%^&*()+]{9,}$";
    }
}
