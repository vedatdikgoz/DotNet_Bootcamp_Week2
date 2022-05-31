using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;   
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var categories=_categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var category =_categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            _categoryService.Delete(category);
            return Ok();
        }
    }
}
