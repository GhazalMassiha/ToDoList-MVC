using ToDoList.Domain.Core.CategoryAgg.DTOs;

namespace ToDoList.Domain.Core.CategoryAgg.Contracts.RepositoryContracts
{
    public interface ICategoryRepository
    {
        public List<CategoryDto> GetAll();
    }
}
