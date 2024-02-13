using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using WebApi.Configs;

//a variable to hold configuration
IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestWithNetCore", Version = "v1" });
});


 builder.Services.AddDependencyInjectionConfiguration(configuration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestWithNetCore"));
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
