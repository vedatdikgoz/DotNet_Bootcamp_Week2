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
        public async Task<IActionResult> GetAll()
        {
            var categories= await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.UpdateAsync(category);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Category category)
        {
            await _categoryService.DeleteAsync(category);
            return Ok();
        }
    }
}
