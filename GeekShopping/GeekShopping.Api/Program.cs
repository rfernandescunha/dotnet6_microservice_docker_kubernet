

//a variable to hold configuration
using GeekShopping.Api.Configs;
using GeekShopping.Api.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Configs;

IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;


builder.Services.AddDependencyInjectionConfiguration(configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenConfig();



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

app.Run();
