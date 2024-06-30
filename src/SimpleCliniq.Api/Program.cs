using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleCliniq.Common.Infrastructure.Configuration;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Extensions;
using SimpleCliniq.Middleware;
using SimpleCliniq.Module.Core.Infrastructure;
using System.Reflection;

//using SimpleCliniq.Module.Core.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDbContext<SimpleClinicContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), cfg =>
    {
        cfg.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

    });
});

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies = [
    //SimpleCliniq.Module.Core.AssemblyReference.Assembly
    ];

//builder.Services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");

//builder.Services.AddInfrastructure(
//    DiagnosticsConfig.ServiceName,
//    [
//        EventsModule.ConfigureConsumers(redisConnectionString),
//        TicketingModule.ConfigureConsumers,
//        AttendanceModule.ConfigureConsumers
//    ],
//    databaseConnectionString,
//    redisConnectionString);

Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddKeyCloak(keyCloakHealthUrl);

builder.Configuration.AddModuleConfiguration(["users"]);

services.AddEndpoints(Assembly.GetExecutingAssembly());

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Run();
