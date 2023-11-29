using DotnetFoundation.Presentation.Middleware;
using MediatR;
using DotnetFoundation.Application;
using DotnetFoundation.Infrastructure;
using Serilog;
using Serilog.Events;
using DotnetFoundation.Core.Interfaces.UserRepo;
using DotnetFoundation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DotnetFoundation.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication()
                .AddInfrastructure();

builder.Services.AddScoped<IUserRepository, UserRepository>();

// DB connection Setup
builder.Services.AddDbContext<UserDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DBConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Logging service Serilogs
builder.Logging.AddSerilog();
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: "logs/log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}{NewLine}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information
    ).CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
