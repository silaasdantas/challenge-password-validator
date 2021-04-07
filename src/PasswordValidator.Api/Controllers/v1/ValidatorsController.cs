using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordValidator.Api.Models;
using PasswordValidator.Core.Interfaces;
using System;
using System.Net;

namespace PasswordValidator.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/validators")]
    public class ValidatorsController : ControllerBase
    {
        private readonly ILogger<ValidatorsController> _logger;
        private readonly IPasswordService _passwordValidatorService;
        public ValidatorsController(IPasswordService passwordValidatorService, ILogger<ValidatorsController> logger)
        {
            _passwordValidatorService = passwordValidatorService;
            _logger = logger;
        }

        [HttpPost("password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] PasswordRequest passwordRequest)
        {
            try
            {
                var result = _passwordValidatorService.IsValid(passwordRequest.Password);
                return Ok(new { isValid = result });
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception.ToString());
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
