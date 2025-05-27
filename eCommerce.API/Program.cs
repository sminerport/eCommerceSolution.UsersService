using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserToAuthenticationResponseMappingProfile).Assembly);

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// Add API explorer services
builder.Services.AddEndpointsApiExplorer();

// Add swagger generator for swagger.json
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Build the web application
WebApplication app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Enable CORS
app.UseCors();

// Add endpoint that can serve the swagger.json file
app.UseSwagger();
// Add swagger UI
app.UseSwaggerUI();

// Auth
// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();