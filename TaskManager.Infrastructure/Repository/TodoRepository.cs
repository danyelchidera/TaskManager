using Microsoft.Extensions.Options;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Enitities;
using TaskManager.Shared.OptionsObject;

namespace TaskManager.Infrastructure.Repository
{
    internal sealed class TodoRepository : ITodoRepository
    {
        private readonly IExternalMockService _mockService;
        private readonly MockApiConfig _mockApiConfig;

        public TodoRepository(IExternalMockService mockService, IOptionsSnapshot<MockApiConfig> mockApiConfig)
        {
            _mockService = mockService;
            _mockApiConfig = mockApiConfig.Value;
        }

        public async Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken) =>
            await _mockService.PostAsync(todo, _mockApiConfig.TaskEnpoint, cancellationToken);
        

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var url = _mockApiConfig.TaskEnpoint + id;
            await _mockService.DeleteAsync(url, cancellationToken);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync(CancellationToken cancellationToken) =>
            await _mockService.GetAsync<IEnumerable<Todo>>(_mockApiConfig.TaskEnpoint, cancellationToken);

        public async Task<Todo> GetAsync(string id, CancellationToken cancellationToken)
        {
            var url = _mockApiConfig.TaskEnpoint + id;
            return await _mockService.GetAsync<Todo>(url, cancellationToken);
        }
    }
}
