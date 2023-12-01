using AluraRPA.Domain.Interfaces;
using AluraRPA.Infra.Data;
using AluraRPA.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using AluraRPA.Infra.CrossCutting.WebScrapping;
using AluraRPA.Service.Services;
using System.Data.SqlClient;
using System.Data;
using AluraRPA.Domain.Entities;
using AluraRPA.Service.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IDbConnection>(c =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddTransient<ICursoService, CursoService>();
builder.Services.AddTransient<IAluraScrappingService, AluraScrappingService>();
builder.Services.AddTransient<IValidator<Curso>, CursoValidator>();

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
