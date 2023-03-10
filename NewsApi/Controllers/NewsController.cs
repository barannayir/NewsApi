using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ILoggerService _logger;

        public NewsController(INewsService newsService, ILoggerService logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
                var result = _newsService.GetById(id);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
                var result = _newsService.GetAll();
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
                var result = _newsService.GetByCategory(categoryId);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }
        

        [HttpPost("add")]
        public IActionResult Add(News news)
        {
                var result = _newsService.Add(news);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(News news)
        {
                var result = _newsService.Update(news);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(News news)
        {
                var result = _newsService.Delete(news);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [HttpPost("deletebyid")]
        public IActionResult DeleteById(int id)
        {
                var result = _newsService.DeleteById(id);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        [HttpPost("changestatus")]
        public IActionResult ChangeStatus(News news)
        {
                var result = _newsService.ChangeStatus(news);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
        }

        




    }
}
