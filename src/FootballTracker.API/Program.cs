using FootballTracker.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using FootballTracker.Application.UseCases.Clubs.ActivateClub;
using FootballTracker.Application.UseCases.Clubs.DeactivateClub;
using FootballTracker.Application.UseCases.Clubs.GetClubById;
using FootballTracker.Application.UseCases.Clubs.ListClubs;
using FootballTracker.Application.UseCases.Clubs.RegisterClub;
using FootballTracker.Application.UseCases.Clubs.UpdateClub;
using FootballTracker.Application.UseCases.Stadiums.ActivateStadium;
using FootballTracker.Application.UseCases.Stadiums.DeactivateStadium;
using FootballTracker.Application.UseCases.Stadiums.GetStadiumById;
using FootballTracker.Application.UseCases.Stadiums.ListStadiums;
using FootballTracker.Application.UseCases.Stadiums.RegisterStadium;
using FootballTracker.Application.UseCases.Stadiums.UpdateStadium;
using FootballTracker.Application.UseCases.Competitions.RegisterCompetition;
using FootballTracker.Application.UseCases.Competitions.UpdateCompetition;
using FootballTracker.Application.UseCases.Competitions.GetCompetitionById;
using FootballTracker.Application.UseCases.Competitions.ListCompetitions;
using FootballTracker.Application.UseCases.Competitions.ActivateCompetition;
using FootballTracker.Application.UseCases.Competitions.DeactivateCompetition;
using FootballTracker.Application.UseCases.Matchs.ApproveMatch;
using FootballTracker.Application.UseCases.Matchs.RejectMatch;
using FootballTracker.Application.UseCases.Matchs.ListMatches;
using FootballTracker.Application.UseCases.Matchs.GetMatchById;

using FootballTracker.Application.UseCases.Users.RegisterUser;
using FootballTracker.Application.UseCases.Visits.RegisterVisit;

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
builder.Services.AddScoped<ListStadiumsHandler>();
builder.Services.AddScoped<GetStadiumByIdHandler>();

builder.Services.AddScoped<ApproveMatchHandler>();
builder.Services.AddScoped<RejectMatchHandler>();
builder.Services.AddScoped<ListMatchesHandler>();
builder.Services.AddScoped<GetMatchByIdHandler>();

builder.Services.AddScoped<RegisterClubHandler>();
builder.Services.AddScoped<UpdateClubHandler>();
builder.Services.AddScoped<ActivateClubHandler>();
builder.Services.AddScoped<DeactivateClubHandler>();
builder.Services.AddScoped<ListClubsHandler>();
builder.Services.AddScoped<GetClubByIdHandler>();

builder.Services.AddScoped<RegisterCompetitionHandler>();
builder.Services.AddScoped<UpdateCompetitionHandler>();
builder.Services.AddScoped<ListCompetitionsHandler>();
builder.Services.AddScoped<GetCompetitionByIdHandler>();
builder.Services.AddScoped<ActivateCompetitionHandler>();
builder.Services.AddScoped<DeactivateCompetitionHandler>();

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