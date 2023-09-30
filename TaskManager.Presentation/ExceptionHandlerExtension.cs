using Microsoft.AspNetCore.Diagnostics;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Exceptions;
using TaskManager.Shared.ResponseModels;

namespace TaskManager.Presentation
{
    public static class ExceptionHandlerExtension
    {
        public static void ConfigureExceptonHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            TodoNotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError

                        };
                        logger.LogError($"Something went wrong:{contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorResponseModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
