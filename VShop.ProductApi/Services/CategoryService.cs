using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            throw new NotImplementedException();
        }
        public Task<CategoryDTO> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddCategory(CategoryDTO categoryDto)
        {
            throw new NotImplementedException();
        }
        public Task UpdateCategory(CategoryDTO categoryDto)
        {
            throw new NotImplementedException();
        }
        public Task RemoveCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
