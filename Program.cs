using ClimateChangeDashboardBackend.Data;
using ClimateChangeDashboardBackend.Interfaces;
using ClimateChangeDashboardBackendApi.Data;
using ClimateChangeDashboardBackendApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IClimateService, ClimateService>(); // Replace ClimateService with the correct implementation class
builder.Services.AddTransient<INaturalEventsService, NaturalEventsService>(); // Replace ClimateService with the correct implementation class

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom services for the Userses
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IAnalyticsRepository, AnalyticsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();


// Add Application Db Context options
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")  // replace with your front-end app's URL
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());  // This allows cookies


app.UseAuthorization();

app.MapControllers();

app.MapGraphQL(path: "/graphql");

app.Run();