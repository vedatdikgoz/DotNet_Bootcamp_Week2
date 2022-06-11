using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<ProductDto>> GetAllProductsWithCategoryAsync();
    }
}
