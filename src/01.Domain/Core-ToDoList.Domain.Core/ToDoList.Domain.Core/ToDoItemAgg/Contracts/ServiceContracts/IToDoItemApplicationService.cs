using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.TaskAgg.DTOs;

namespace ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts
{
    public interface IToDoItemApplicationService
    {
        public List<ToDoItemDto> GetUserItem(int userId, string search = null, int? categoryId = null, string sort = null);
        public Result<bool> CreateItem(int userId, ToDoItemCreateDto itemDto);
        public Result<bool> MarkItemComplete(int todoId, ToDoItemEditDto itemDto);
        public Result<bool> Delete(int itemId);
    }
}
