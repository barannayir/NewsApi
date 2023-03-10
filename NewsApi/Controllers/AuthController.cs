using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly ILoggerService _logger;

        public AuthController(ISecurityService securityService, ILoggerService logger)
        {
            _securityService = securityService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var result = _securityService.Login(userLoginDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Register(UserSignUpDto userRegisterDto)
        {
            var result = _securityService.SignUp(userRegisterDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
