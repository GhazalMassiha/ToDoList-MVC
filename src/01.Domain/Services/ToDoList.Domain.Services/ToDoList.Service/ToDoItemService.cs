using ToDoList.Domain.Core.TaskAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.TaskAgg.DTOs;
using ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts;

namespace ToDoList.Service
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService (IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public bool Create(ToDoItemCreateDto itemCreate)
        {
            return _toDoItemRepository.Create(itemCreate);
        }

        public int Delete(int itemId)
        {
            return _toDoItemRepository.Delete(itemId);
        }

        public ToDoItemDto GetById(int itemId)
        {
            return _toDoItemRepository.GetById(itemId);
        }

        public List<ToDoItemDto> GetByItemUserId(int userId)
        {
            return _toDoItemRepository.GetByItemUserId(userId);
        }

        public bool Update(int itemId, ToDoItemEditDto item)
        {
            return _toDoItemRepository.Update(itemId, item);
        }

        public void Save()
        {
            _toDoItemRepository.Save();
        }
    }
}
