using Microsoft.Extensions.Options;
using TaskManager.Domain.Contracts;
using TaskManager.Shared.OptionsObject;

namespace TaskManager.Infrastructure.Repository
{
    internal sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ITodoRepository> _todoRespository;

        public RepositoryManager(IExternalMockService mockService, IOptionsSnapshot<MockApiConfig> mockApiConfig)
        {
            _todoRespository = new Lazy<ITodoRepository>(() => new TodoRepository(mockService, mockApiConfig));
        }
        public ITodoRepository TodoRepository => _todoRespository.Value;
    }
}
