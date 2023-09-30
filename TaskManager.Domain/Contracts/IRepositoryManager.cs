namespace TaskManager.Domain.Contracts
{
    public interface IRepositoryManager
    {
        ITodoRepository TodoRepository { get; }    
    }
}
