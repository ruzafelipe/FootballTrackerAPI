using FootballTracker.Application.UseCases.Clubs.ActivateClub;
using FootballTracker.Application.UseCases.Clubs.DeactivateClub;
using FootballTracker.Application.UseCases.Clubs.GetClubById;
using FootballTracker.Application.UseCases.Clubs.ListClubs;
using FootballTracker.Application.UseCases.Clubs.RegisterClub;
using FootballTracker.Application.UseCases.Clubs.UpdateClub;
using FootballTracker.Application.UseCases.Matchs.RegisterMatch;
using FootballTracker.Application.UseCases.Stadiums.ActivateStadium;
using FootballTracker.Application.UseCases.Stadiums.DeactivateStadium;
using FootballTracker.Application.UseCases.Stadiums.GetStadiumById;
using FootballTracker.Application.UseCases.Stadiums.ListStadiums;
using FootballTracker.Application.UseCases.Stadiums.RegisterStadium;
using FootballTracker.Application.UseCases.Stadiums.UpdateStadium;
using FootballTracker.Application.UseCases.Users.RegisterUser;
using FootballTracker.Application.UseCases.Visits.RegisterVisit;
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
builder.Services.AddScoped<UpdateStadiumHandler>();
builder.Services.AddScoped<ActivateStadiumHandler>();
builder.Services.AddScoped<DeactivateStadiumHandler>();
builder.Services.AddScoped<ListStadiumHandler>();
builder.Services.AddScoped<GetStadiumByIdHandler>();

builder.Services.AddScoped<RegisterMatchHandler>();

builder.Services.AddScoped<RegisterClubHandler>();
builder.Services.AddScoped<UpdateClubHandler>();
builder.Services.AddScoped<ActivateClubHandler>();
builder.Services.AddScoped<DeactivateClubHandler>();
builder.Services.AddScoped<ListClubHandler>();
builder.Services.AddScoped<GetClubByIdHandler>();

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