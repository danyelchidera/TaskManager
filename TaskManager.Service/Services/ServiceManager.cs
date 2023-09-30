using AutoMapper;
using TaskManager.Domain.Contracts;
using TaskManager.ServiceContracts.Contracts;

namespace TaskManager.Service.Services
{
    internal sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITodoService> _todoService;

        public ServiceManager(IRepositoryManager repoManager, IMapper mapper)
        {
            _todoService = new Lazy<ITodoService>(() => new TodoService(mapper, repoManager));
        }
        public ITodoService TodoService => _todoService.Value;
    }
}
