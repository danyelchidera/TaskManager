using Microsoft.AspNetCore.Mvc;
using TaskManager.Presentation.ActionFilters;
using TaskManager.ServiceContracts.Contracts;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Presentation.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TodoController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public TodoController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelFilter<CreateTodoModel>))]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoModel model, CancellationToken cancellationToken)
        {
            var todo = await _serviceManager.TodoService.AddAsync(model, cancellationToken);
            return Ok(todo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var todos = await _serviceManager.TodoService.GetAllAsync(cancellationToken);
            return Ok(todos);
        }

        [HttpGet("{id}", Name = "Todo")]
        public async Task<IActionResult> GetTodo(string id, CancellationToken cancellationToken)
        {
            var todo = await _serviceManager.TodoService.GetAsync(id, cancellationToken);
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _serviceManager.TodoService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
