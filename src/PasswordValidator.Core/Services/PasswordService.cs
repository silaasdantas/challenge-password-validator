using PasswordValidator.Core.Interfaces;

namespace PasswordValidator.Core.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordValidator _validator;
        public PasswordService(IPasswordValidator validator)
        {
            _validator = validator;
        }

        public bool IsValid(string password)
        {
            return _validator.IsValid(password);
        }
    }
}
