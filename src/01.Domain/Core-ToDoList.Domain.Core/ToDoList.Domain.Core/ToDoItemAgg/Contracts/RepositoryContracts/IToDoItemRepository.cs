using ToDoList.Domain.Core.TaskAgg.DTOs;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;

namespace ToDoList.Domain.Core.TaskAgg.Contracts.RepositoryContracts
{
    public interface IToDoItemRepository
    {
        public List<ToDoItemDto> GetByItemUserId(int userId);
        public ToDoItemDto GetById(int itemId);
        public bool Create(ToDoItemCreateDto itemCreate);
        public bool Update(int itemId, ToDoItemEditDto item);
        public int Delete(int itemId);
        public void Save();
    }
}
