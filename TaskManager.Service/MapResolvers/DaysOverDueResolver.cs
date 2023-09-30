using AutoMapper;
using TaskManager.Domain.Enitities;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.MapResolvers
{
    public class DaysOverDueResolver : IValueResolver<Todo, TodoViewModel, int>
    {
        public int Resolve(Todo source, TodoViewModel destination, int destMember, ResolutionContext context)
        {
            if (!source.TodoStatus)
            {
                return source.AllottedTimeInDays - source.ElapsedTimeInDays;
            }
            return 0;
        }
    }
}
