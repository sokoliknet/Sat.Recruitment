using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sat.Recruitment.Api;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddConfig(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Refactoring",
        Description = "An ASP.NET Core Web API"
    });
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();