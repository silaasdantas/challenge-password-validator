using Microsoft.Extensions.Logging;
using PasswordValidator.Core.Interfaces;
using System;

namespace PasswordValidator.Core.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordValidator _validator;
        private readonly ILogger<PasswordService> _logger;

        public PasswordService(IPasswordValidator validator, ILogger<PasswordService> logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public bool IsValid(string password)
        {
            try
            {
                return _validator.IsValid(password);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return false;
            }
        }
    }
}
