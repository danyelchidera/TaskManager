using AutoMapper;
using TaskManager.Domain.Enitities;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.MapResolvers
{
    public class EndDateResolver : IValueResolver<Todo, TodoViewModel, DateTime>
    {
        public DateTime Resolve(Todo source, TodoViewModel destination, DateTime destMember, ResolutionContext context)
        {
            return source.StartDate.AddDays(source.ElapsedTimeInDays);
        }
    }
}
