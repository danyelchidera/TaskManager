namespace TaskManager.ServiceContracts.ViewModels
{
    public sealed class CreateTodoModel
    {
        public string TodoName { get; init; }
        public string TodoDescription { get; init; }
        public int AllottedTimeInDays { get; init; }
    }
}
