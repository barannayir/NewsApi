using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoggerService _logger;

        public CategoryController(ICategoryService categoryService, ILoggerService logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _categoryService.GetAll();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _categoryService.GetById(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {

            var result = _categoryService.Add(category);
            if (result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Category category)
        {

            var result = _categoryService.Update(category);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {

            var result = _categoryService.Delete(category);
            if (result.IsSuccess)
                return Ok(result);
              
            return BadRequest(result);

        }


    }
}
