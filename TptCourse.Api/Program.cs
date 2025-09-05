using TptCourse.Application.Interfaces;
using TptCourse.Application.Mappings;
using TptCourse.Application.Services;
using TptCourse.Infrastructure.Repositories;
using TptCourse.Infrastructure.DatabaseConnection;
using TptCourse.Infrastructure.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// AutoMapper
services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Database connection binding
services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
services.AddScoped<IDataBaseConnection, DataBaseConnection>();

// Dependency Injection for services and repositories
services.AddScoped<IApplicationFormService, ApplicationFormService>();
services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
services.AddScoped<IBatchService, BatchService>();
services.AddScoped<IBatchRepository, BatchRepository>();
services.AddScoped<ICourseService, CourseService>();
services.AddScoped<ICourseRepository, CourseRepository>();

// Controllers
services.AddControllers();

// CORS
services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger/OpenAPI (no JWT security definition)
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TptCourse.API", Version = "v1" });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TptCourse.API v1"));

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");

app.MapControllers();

app.Run();
