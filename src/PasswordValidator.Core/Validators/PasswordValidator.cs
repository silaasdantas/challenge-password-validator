using PasswordValidator.Core.Constants;
using PasswordValidator.Core.Interfaces;
using System.Text.RegularExpressions;

namespace PasswordValidator.Core.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool IsValid(string value)
        {
            var regex = new Regex(RegexPatternsConstants.PASSWORD_PATTERN);
            var match = regex.Match(value.ToString());
            return match.Success;
        }
    }
}
