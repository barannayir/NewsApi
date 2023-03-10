using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ILogger<INewsService> _logger;

        public NewsController(INewsService newsService, ILogger<INewsService> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _newsService.GetById(id);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("News GetAll failed.", ex);

            }
            return BadRequest(   );

        }
    }
}
