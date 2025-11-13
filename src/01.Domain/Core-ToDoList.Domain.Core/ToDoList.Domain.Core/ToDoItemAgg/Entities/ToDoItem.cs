using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.CategoryAgg.Entities;
using ToDoList.Domain.Core.UserAgg.Entities;

namespace ToDoList.Domain.Core.ToDoItemAgg.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
