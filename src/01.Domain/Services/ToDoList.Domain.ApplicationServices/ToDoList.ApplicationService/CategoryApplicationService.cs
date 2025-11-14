using ToDoList.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.CategoryAgg.DTOs;

namespace ToDoList.ApplicationService
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryService _categoryService;

        public CategoryApplicationService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _categoryService.GetAll();
        }
    }
}
