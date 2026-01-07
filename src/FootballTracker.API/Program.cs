using FootballTracker.Application.UseCases;
using FootballTracker.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolver =
            new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
    });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureModule(builder.Configuration);

builder.Services.AddScoped<RegisterVisitHandler>();
builder.Services.AddScoped<RegisterUserHandler>();
builder.Services.AddScoped<RegisterStadiumHandler>();
builder.Services.AddScoped<RegisterClubHandler>();
builder.Services.AddScoped<RegisterMatchHandler>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Football Tracker API",
        Version = "v1",
        Description = "API for tracking football stadium visits"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football Tracker API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();