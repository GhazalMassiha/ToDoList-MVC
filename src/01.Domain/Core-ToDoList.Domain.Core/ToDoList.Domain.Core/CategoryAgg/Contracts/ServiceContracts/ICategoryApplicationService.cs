using ToDoList.Domain.Core.CategoryAgg.DTOs;

namespace ToDoList.Domain.Core.CategoryAgg.Contracts.ServiceContracts
{
    public interface ICategoryApplicationService
    {
        public List<CategoryDto> GetAllCategories();
    }
}
