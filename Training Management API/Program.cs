using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using Training_Management_API.Data;
using Training_Management_API.Mappings;
using Training_Management_API.Models;
using Training_Management_API.Repositories.Implementations;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Services.Implementations;
using Training_Management_API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration with XML comments
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Training Management API Exercise",
        Version = "v1",
        Description = "API for managing training programs"
    });

    // Adding XML comments for controller summaries
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Configuration.AddEnvironmentVariables();

// AutoMapper configuration
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

// Database context configuration
builder.Services.AddDbContext<TrainingManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection for repositories 
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();

// Dependency Injection for services
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Unxpected error handling gives clear json response instead of a stack trace
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            var result = JsonSerializer.Serialize(new { error = error.Error.Message });
            await context.Response.WriteAsync(result);
        }
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
