using ToDoList.Domain.Core.TaskAgg.DTOs;

namespace ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts
{
    public interface IToDoItemService
    {
        public List<ToDoItemDto> GetByItemUserId(int userId);
        public ToDoItemDto GetById(int itemId);
        public bool Create(ToDoItemCreateDto itemCreate);
        public bool Update(int itemId, ToDoItemEditDto item);
        public int Delete(int itemId);
        public void Save();
    }
}
