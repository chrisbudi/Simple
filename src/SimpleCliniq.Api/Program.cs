using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Infrastructure;
using System.Reflection;
//using SimpleCliniq.Module.Core.Infrastructure;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var services = builder.Services;

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


services.AddDbContext<SimpleClinicContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), cfg =>
    {
        cfg.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

    });
});


services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


services.AddEndpoints(Assembly.GetExecutingAssembly()).ConfigureHttpJsonOptions(option =>
{
    option.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();


app.MapEndpoints();

app.Run();
