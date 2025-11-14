namespace ToDoList.Presentation.MVC.Models
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string CategoryName { get; set; }
    }
}
