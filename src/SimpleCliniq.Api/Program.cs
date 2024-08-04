using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Simple.Common.Application;
using Simple.Common.Infrastructure;
using Simple.Common.Infrastructure.Configuration;
using Simple.Common.Presentation.Endpoints;
using SimpleCliniq.Extensions;
using SimpleCliniq.Middleware;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniq.Module.Users.Infrastructure;
using SimpleCliniq.OpenTelemetry;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies = [
    SimpleCliniq.Module.Users.Application.AssemblyReference.Assembly
    ];

builder.Services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("DefaultConnection");
string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");

builder.Services.AddInfrastructure(
    DiagnosticsConfig.ServiceName,
    [
        //AttendanceModule.ConfigureConsumers
    ],
    databaseConnectionString,
    redisConnectionString);

Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddKeyCloak(keyCloakHealthUrl);



builder.Configuration.AddModuleConfiguration(["users", "cores",]);

builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddCoresModule(builder.Configuration);

services.AddEndpoints(Assembly.GetExecutingAssembly());

//// module for clinical

//builder.Services.AddPharmacyModule(builder.Configuration);

//// module for patient

//builder.Services.AddAppointmentModule(builder.Configuration);
//builder.Services.AddAppointmentModule(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();

    //app.ApplyMigrations<CoreDbContext>();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseLogContext();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

app.Run();


public partial class Program;
