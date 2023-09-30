using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Enitities;
using TaskManager.Domain.Exceptions;
using TaskManager.ServiceContracts.Contracts;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.Services
{
    internal sealed class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public TodoService(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
           
        }
        public async Task<TodoViewModel> AddAsync(CreateTodoModel model, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Todo>(model);

            var createdTodo = await _repositoryManager.TodoRepository.AddAsync(todo, cancellationToken);

            return _mapper.Map<TodoViewModel>(createdTodo);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var todo = await _repositoryManager.TodoRepository.GetAsync(id, cancellationToken);

            if (todo == null)
                throw new TodoNotFoundException();

            await _repositoryManager.TodoRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<TodoViewModel> GetAsync(string id, CancellationToken cancellationToken)
        {
            var todo = await _repositoryManager.TodoRepository.GetAsync(id, cancellationToken);

            return _mapper.Map<TodoViewModel>(todo);
        }

        public async Task<IEnumerable<TodoViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var todos = await _repositoryManager.TodoRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TodoViewModel>>(todos);
        }
    }
}
