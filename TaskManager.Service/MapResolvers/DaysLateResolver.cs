using AutoMapper;
using TaskManager.Domain.Enitities;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.MapResolvers
{
    public class DaysLateResolver : IValueResolver<Todo, TodoViewModel, int>
    {
        public int Resolve(Todo source, TodoViewModel destination, int destMember, ResolutionContext context)
        {
            if (source.TodoStatus)
            {
                return source.ElapsedTimeInDays - source.AllottedTimeInDays;
            }
            return 0;
        }
    }
    
}
