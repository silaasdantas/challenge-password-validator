using System.ComponentModel.DataAnnotations;

namespace PasswordValidator.Api.Models
{
    public class PasswordRequest
    {
        [Required()]
        public string Password { get; set; }
    }
}
