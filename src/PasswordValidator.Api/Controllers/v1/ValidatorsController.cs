using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Api.Models;
using PasswordValidator.Core.Interfaces;

namespace PasswordValidator.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/validators")]
    public class ValidatorsController : ControllerBase
    {
        private readonly IPasswordService _passwordValidatorService;
        public ValidatorsController(IPasswordService passwordValidatorService)
        {
            _passwordValidatorService = passwordValidatorService;
        }

        [HttpPost("password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] PasswordRequest passwordRequest)
        {
            var result = _passwordValidatorService.IsValid(passwordRequest.Password);
            return Ok(new { isValid = result });
        }
    }
}
