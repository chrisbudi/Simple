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
using SimpleCliniq.Module.Core.Presentation;
using SimpleCliniq.Module.Users.Infrastructure;
using SimpleCliniq.OpenTelemetry;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies = [
    SimpleCliniq.Module.Users.Application.AssemblyReference.Assembly,
    SimpleCliniq.Module.Core.Application.AssemblyReference.Assembly,
    ];

builder.Services.AddApplication(moduleApplicationAssemblies);

string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("DefaultConnection");
string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");

builder.Services.AddInfrastructure(
    DiagnosticsConfig.ServiceName,
    [
    ],
    databaseConnectionString,
    redisConnectionString);



builder.Configuration.AddModuleConfiguration(["users", "cores",]);
Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthUrl();


builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString)
    .AddKeyCloak(keyCloakHealthUrl);


builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddCoresModule(builder.Configuration);

builder.Services.AddCorePresentationModule();

services.AddEndpoints(Assembly.GetExecutingAssembly());


// add cors all origins
const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


// builder.Services.AddControllers().AddNewtonsoftJson(options =>
// {
//     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
// });


services.AddEndpoints(Assembly.GetExecutingAssembly()).ConfigureHttpJsonOptions(option =>
{
    option.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});



var app = builder.Build();

// app add cors
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
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
