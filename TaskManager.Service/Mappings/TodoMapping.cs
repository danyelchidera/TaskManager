

using AutoMapper;
using TaskManager.Domain.Enitities;
using TaskManager.Service.MapResolvers;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.Mappings
{
    public class TodoMapping : Profile
    {
        public TodoMapping()
        {
            CreateMap<CreateTodoModel, Todo>()
                .AfterMap((src, dest) =>
                {
                    dest.StartDate = DateTime.Now;
                });
            
            CreateMap<Todo, TodoViewModel>()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom<EndDateResolver>())
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom<DueDateResolver>())
                .ForMember(dest => dest.DaysOverDue, opt => opt.MapFrom<DaysOverDueResolver>())
                .ForMember(dest => dest.DaysLate, opt => opt.MapFrom<DaysLateResolver>());
        }
    }
}
