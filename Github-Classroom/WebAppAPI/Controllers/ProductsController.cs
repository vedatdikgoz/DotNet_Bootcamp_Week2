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
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }


        //ürünleri kategori isimleri ile listeleme
        [HttpGet("getallproductswithcategory")]
        public IActionResult GetAllProductsWithCategory()
        {
            var products = _productService.GetAllProductsWithCategory();
            return Ok(products);
        }




        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);          
            return Ok(product);
           
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);           
            return Ok();

        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            _productService.Delete(product);
            return Ok();

        }
    }
}
