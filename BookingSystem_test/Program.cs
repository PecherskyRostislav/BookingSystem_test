using API.Behaviors;
using API.DataStore;
using API.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var connection = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseMySql(
       connectionString: connection,
       serverVersion: ServerVersion.AutoDetect(connection));
});

builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaivor<,>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
