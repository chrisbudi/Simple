using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Simple.Common.Application;
using Simple.Common.Infrastructure;
using Simple.Common.Infrastructure.Configuration;
using Simple.Common.Presentation.Endpoints;
using SimpleCliniq.Extensions;
using SimpleCliniq.Middleware;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniq.Module.Core.Infrastructure.Database;
using SimpleCliniq.Module.Users.Infrastructure;
using SimpleCliniq.OpenTelemetry;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDbContext<CoreDbContext>(options =>
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
    //SimpleCliniq.Module.Core.Application.AssemblyReference.Assembly,
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


services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.AddModuleConfiguration(["users", "cores",]);


builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddCoresModule(builder.Configuration);

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

