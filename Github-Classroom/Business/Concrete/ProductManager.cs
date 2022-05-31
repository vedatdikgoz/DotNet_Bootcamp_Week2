using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public Product GetById(int id)
        {
            return _productRepository.Get(p=>p.Id==id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public List<ProductDto> GetAllProductsWithCategory()
        {
            return _productRepository.GetAllProductsWithCategory();
        }
    }
}
