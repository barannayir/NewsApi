using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerService _logger;

        public UserController(IUserService userService, ILoggerService logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpPost("adduser")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getall2")]
        public IActionResult GetAll2()
        {
            var result = _userService.GetAll();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetByUserId(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyusername")]
        public IActionResult GetByUsername(string username)
        {
            var result = _userService.GetByUserName(username);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        
        
        
        
    }
}
