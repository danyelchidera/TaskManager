using TaskManager.Infrastructure.Extensions;
using NLog;
using TaskManager.Domain.Contracts;
using TaskManager.Presentation;
using TaskManager.Service.Extensions;
using TaskManager.Presentation.ActionFilters;
using FluentValidation;
using TaskManager.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.RegisterExternalServices(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoModelValidator>();
builder.Services.ConfigureOptions(builder.Configuration);

builder.Services.AddScoped(typeof(ValidateModelFilter<>));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TaskManager", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptonHandler(logger);

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
