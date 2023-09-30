using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.ServiceContracts.Contracts
{
    public interface ITodoService
    {
        Task<TodoViewModel> AddAsync(CreateTodoModel model, CancellationToken cancellationToken);
        Task<TodoViewModel> GetAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<TodoViewModel>> GetAllAsync(CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
