using ToDoList.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.CategoryAgg.DTOs;
using ToDoList.Infrastructure.EFCore.Persistence;
using ToDoList.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;

namespace ToDoList.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
