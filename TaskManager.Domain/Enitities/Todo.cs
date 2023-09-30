namespace TaskManager.Domain.Enitities
{
    public class Todo
    {
        public string TodoId { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTimeInDays { get; set; }
        public int ElapsedTimeInDays { get; set; }
        public bool TodoStatus { get; set; }
    }
}
