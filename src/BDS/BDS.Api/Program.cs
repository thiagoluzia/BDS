using BDS.Api.Filters;
using BDS.Application.CQRS.Queries.Doadores.Consultar;
using BDS.Application.Validators;
using BDS.Core.Repositories;
using BDS.Infrastructure.Persistences;
using BDS.Infrastructure.Persistences.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Interfaces
builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();

//Validaçoes
builder.Services.AddValidatorsFromAssemblyContaining<IncluirDoadorValidator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ConsultarDoador)));
//builder.Services.AddMediatR()


// Adicionando configurações de Filtros e Validações
builder.Services.AddControllers(options => options.Filters.Add(typeof(Filters)));

//Integrações


//Infra
var connection = builder.Configuration.GetConnectionString("BDS_ConnectionString");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);




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
