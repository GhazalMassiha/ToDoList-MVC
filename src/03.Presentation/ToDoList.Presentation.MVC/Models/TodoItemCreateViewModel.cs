namespace ToDoList.Presentation.MVC.Models
{
    public class TodoItemCreateViewModel
    {
        public string Title { get; set; }
        public string DueDateString { get; set; } 
        public int CategoryId { get; set; }
    }
}
