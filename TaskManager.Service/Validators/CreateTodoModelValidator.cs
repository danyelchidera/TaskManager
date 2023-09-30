using FluentValidation;
using TaskManager.ServiceContracts.ViewModels;

namespace TaskManager.Service.Validators
{
    public class CreateTodoModelValidator : AbstractValidator<CreateTodoModel>
    {
        public CreateTodoModelValidator()
        {
            RuleFor(x => x.TodoName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.TodoDescription)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
