using BDS.Api.Filters;
using BDS.Application.Abstractions.External.ViaCEP;
using BDS.Application.CQRS;
using BDS.Application.Validators;
using BDS.Core.Repositories;
using BDS.Infrastructure.Integrations.ViaCep.Services;
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

//INTEGRAÇÕES
builder.Services.AddHttpClient<IApiViaCepService, ApiViaCepService>();

//Interfaces
builder.Services.AddScoped<IViaCepService, ViaCepService>();

builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();

//Validaçoes
builder.Services.AddValidatorsFromAssemblyContaining<IncluirDoadorValidator>();
builder.Services.AddMediatR(cfg  => cfg.RegisterServicesFromAssemblyContaining(typeof(CQRSContract)));
//builder.Services.AddMediatR()


// Adicionando configurações de Filtros e Validações
builder.Services.AddControllers(options => options.Filters.Add(typeof(Filters)));

//builder.Services.AddMvc(options =>
//{
//    options.SuppressAsyncSuffixInActionNames = false;
//});
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
