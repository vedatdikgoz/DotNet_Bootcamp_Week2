using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var categories= await _categoryRepository.GetAllAsync();
            return new SuccessDataResult<List<Category>>(categories, Messages.CategoriesListed);   
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {           
            return new SuccessDataResult<Category>(await _categoryRepository.GetAsync(c => c.Id == id), Messages.CategoryListed);
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
