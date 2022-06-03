using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var product= await _productRepository.GetAsync(p=>p.Id==id);
            return new SuccessDataResult<Product>(product, Messages.ProductListed);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var products= await _productRepository.GetAllAsync();
            return new SuccessDataResult<List<Product>>(products, Messages.ProductsListed);
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public async Task<IDataResult<List<ProductDto>>> GetAllProductsWithCategoryAsync()
        {
            var result= await _productRepository.GetAllProductsWithCategoryAsync();
            return new SuccessDataResult<List<ProductDto>>(result, Messages.ProductsWithCategoryListed);
            
        }
    }
}
