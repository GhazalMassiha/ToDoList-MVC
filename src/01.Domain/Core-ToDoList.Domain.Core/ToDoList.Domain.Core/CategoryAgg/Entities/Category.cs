using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;

namespace ToDoList.Domain.Core.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
