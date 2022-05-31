using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);   
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();    
        }

        public Category GetById(int id)
        {
            return _categoryRepository.Get(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
