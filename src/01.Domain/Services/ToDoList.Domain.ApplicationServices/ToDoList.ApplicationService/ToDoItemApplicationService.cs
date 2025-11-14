using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using ToDoList.Domain.Core.CategoryAgg.Entities;
using ToDoList.Domain.Core.TaskAgg.DTOs;
using ToDoList.Domain.Core.ToDoItemAgg.Contracts.ServiceContracts;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;

namespace ToDoList.ApplicationService
{
    public class ToDoItemApplicationService : IToDoItemApplicationService
    {
        private readonly IToDoItemService _toDoService;
        public ToDoItemApplicationService(IToDoItemService toDoService)
        {
            _toDoService = toDoService;
        }

        public List<ToDoItemDto> GetUserItem(int userId, string search = null, int? categoryId = null, string sort = null)
        {
            var items = _toDoService.GetByItemUserId(userId);

            if (!string.IsNullOrEmpty(search))
                items = items.Where(t => t.Title.Contains(search)).ToList();

            if (categoryId.HasValue)
                items = items.Where(t => t.CategoryId == categoryId.Value).ToList();

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Title")
                    items = items.OrderBy(t => t.Title).ToList();
                else if (sort == "DueDate")
                    items = items.OrderBy(t => t.DueDate).ToList();
                else if (sort == "IsCompleted")
                    items = items.OrderBy(t => t.IsCompleted).ToList();
            }

            return items;
        }

        public Result<bool> CreateItem(int userId, ToDoItemCreateDto itemDto)
        {
            var item = new ToDoItemCreateDto
            {
                UserId = userId,
                Title = itemDto.Title,
                DueDate = itemDto.DueDate,
                CategoryId = itemDto.CategoryId,
                IsCompleted = false
            };
            var success = _toDoService.Create(item);
            if (!success)
                return Result<bool>.Failure("ثبت کار با خطا مواجه شد.");

            return Result<bool>.Success("کار با موفقیت ثبت شد.", true);
        }

        public Result<bool> MarkItemComplete(int todoId, ToDoItemEditDto itemDto)
        {
            var existing = _toDoService.GetById(todoId);
            if (existing == null)
                return Result<bool>.Failure("کار مورد نظر پیدا نشد.");

            var updated = _toDoService.Update(todoId, itemDto);
            if (!updated)
                return Result<bool>.Failure("ویرایش کار با خطا مواجه شد.");

            return Result<bool>.Success("کار با موفقیت ویرایش شد.", true);
        }

        public Result<bool> Delete(int itemId)
        {
            var deleted = _toDoService.Delete(itemId);

            if (deleted == 0)
                return Result<bool>.Failure("خطایی رخ داده است.");

            _toDoService.Save();

            return Result<bool>.Success("کار با موفقیت حدف شد.");
        }
    }
}
