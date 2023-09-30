namespace TaskManager.ServiceContracts.Contracts
{
    public interface IServiceManager
    {
        ITodoService TodoService { get; }
    }
}
