using ToDoList.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.CategoryAgg.DTOs;
using ToDoList.Domain.Core.CategoryAgg.Entities;
using ToDoList.Infrastructure.EFCore.Persistence;

namespace ToDoList.Infrastructure.EFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
            return _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }
    }
}
