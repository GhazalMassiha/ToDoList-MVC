using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Core.TaskAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.TaskAgg.DTOs;
using ToDoList.Infrastructure.EFCore.Persistence;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;


namespace ToDoList.Infrastructure.EFCore.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _context;

        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ToDoItemDto> GetByItemUserId(int userId)
        {
            return _context.ToDoItems.Where(u =>  u.UserId == userId)
                .Select(t => new ToDoItemDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    CreatedAt = t.CreatedAt,
                    DueDate = t.DueDate,
                    IsCompleted = t.IsCompleted,
                    CategoryId = t.CategoryId
                })
                .ToList();
        }

        public ToDoItemDto GetById(int itemId)
        {
            return _context.ToDoItems.Where(b => b.Id == itemId)
               .Select(t => new ToDoItemDto()
               {
                   Id = t.Id,
                   Title = t.Title,
                   CreatedAt = t.CreatedAt,
                   DueDate = t.DueDate,
                   IsCompleted = t.IsCompleted,
                   CategoryId = t.CategoryId
               }).FirstOrDefault()!;
        }

        public bool Create(ToDoItemCreateDto itemCreate)
        {
            var item = new ToDoItem()
            {
                Title = itemCreate.Title,
                DueDate = itemCreate.DueDate,
                IsCompleted = itemCreate.IsCompleted,
                CategoryId = itemCreate.CategoryId,
                UserId = itemCreate.UserId
            };

            _context.Add(item);
            Save();
            return true;
        }

        public bool Update(int itemId, ToDoItemEditDto item)
        {
            var updatedRows = _context.ToDoItems.Where(b => b.Id == itemId).ExecuteUpdate(setter => setter
               .SetProperty(b => b.IsCompleted, item.IsCompleted)
           );
            return updatedRows > 0;
        }

        public int Delete(int itemId)
        {
            return _context.ToDoItems.Where(u => u.Id == itemId).ExecuteDelete();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
