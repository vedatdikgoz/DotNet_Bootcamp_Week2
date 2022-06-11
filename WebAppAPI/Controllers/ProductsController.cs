using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var products =await _productService.GetAllAsync();
            return Ok(products);
        }


        //ürünleri kategori isimleri ile listeleme
        [HttpGet("getallproductswithcategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var products = await _productService.GetAllProductsWithCategoryAsync();
            return Ok(products);
        }




        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);          
            return Ok(product);
           
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _productService.AddAsync(product);           
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.UpdateAsync(product);
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productService.DeleteAsync(product);
            return Ok();

        }
    }
}
