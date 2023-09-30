using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Shared.ResponseModels;

namespace TaskManager.Presentation.ActionFilters
{
    public class ValidateModelFilter<TModel> : IAsyncActionFilter
    where TModel : class
    {
        private readonly IValidator<TModel> _validator;

        public ValidateModelFilter(IValidator<TModel> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.ActionArguments.TryGetValue("model", out var model) && model is TModel)
            {
                var validationResult = await _validator.ValidateAsync((TModel)model);

                if (!validationResult.IsValid)
                {
                    var response = new ValidationErrorResponse
                    {
                        ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                        StatusCode = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(response);
                    return;
                }
            }

            await next();
        }
    }
}
