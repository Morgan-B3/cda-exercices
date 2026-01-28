namespace TPTodolist.Models
{
    public class TodoTask
    {
        public string Name { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }

        public TodoTask() { }

        public TodoTask (string name)
        {
            Name = name;
            DateCreated = DateTime.Now;
        }
    }
}
