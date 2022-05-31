using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EfEntityRepositoryBase<Product, DataContext>, IProductRepository
    {
        public List<ProductDto> GetAllProductsWithCategory()
        {
            using(var context = new DataContext())
            {
                //kategori adını çekebilmek için tablolar arasında join işlemi yapılması
                var result = from p in context.Products
                             join c in context.Categories
                             on p.Id equals c.Id
                             select new ProductDto
                             {
                                 Id = c.Id,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice,
                                 Amount = p.Amount,
                             };
              return result.ToList();
            }
        }
    }
}
