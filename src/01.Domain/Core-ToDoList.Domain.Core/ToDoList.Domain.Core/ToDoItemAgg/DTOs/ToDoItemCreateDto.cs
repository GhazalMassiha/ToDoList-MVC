using ToDoList.Domain.Core.CategoryAgg.Entities;

namespace ToDoList.Domain.Core.TaskAgg.DTOs
{
    public class ToDoItemCreateDto
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
