using Microsoft.Extensions.Configuration;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Domain.Context;
using Persistance.Abstracts;
using Persistance.Concreate;
using Persistance.Repository;
using Persistance.UOW;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddJsonFile($"appsettings.Development.json", optional: true)
 .AddEnvironmentVariables()
 .Build();

// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskApi", Version = "v1" });
});

builder.Services.AddApplicationLayer(configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.DisallowCredentials(); // Gerekirse bu satýrý ekleyebilirsiniz
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();
app.UseRouting();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
