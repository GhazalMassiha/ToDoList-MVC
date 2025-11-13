using ToDoList.Domain.Core._common;
using ToDoList.Domain.Core.ToDoItemAgg.Entities;

namespace ToDoList.Domain.Core.UserAgg.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
