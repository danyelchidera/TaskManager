namespace TaskManager.ServiceContracts.ViewModels
{
    public sealed class TodoViewModel
    {
        public string TodoId { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTimeInDays { get; set; }
        public int ElapsedTimeInDays { get; set; }
        public bool TodoStatus { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysOverDue { get; set; }
        public int DaysLate { get; set; }

    }
}
