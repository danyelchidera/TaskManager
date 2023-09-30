using TaskManager.Domain.Enitities;

namespace TaskManager.Domain.Contracts
{
    public interface ITodoRepository
    {
        Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken);
        Task<Todo> GetAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Todo>> GetAllAsync(CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
