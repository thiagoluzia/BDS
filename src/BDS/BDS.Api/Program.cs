using BDS.Api.Filters;
using BDS.Application.Abstractions.External.ViaCEP;
using BDS.Application.Abstractions.Workers;
using BDS.Application.CQRS;
using BDS.Application.Validators;
using BDS.Core.Entities;
using BDS.Core.Enums;
using BDS.Core.Repositories;
using BDS.Infrastructure.Integrations.ViaCep.Services;
using BDS.Infrastructure.Persistences;
using BDS.Infrastructure.Persistences.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Hangfire;
using BDS.Infrastructure.Integrations.Sendgrid.Services;
using SendGrid.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banco de Doação de Sangue", Version = "V1" });
    //c.SchemaFilter<EnumSchemaFilter>();
});

//INTEGRAÇÕES
builder.Services.AddHttpClient<IApiViaCepService, ApiViaCepService>();
builder.Services.AddSingleton<ISendgridService, SendgridService>();

//Interfaces
builder.Services.AddScoped<IViaCepService, ViaCepService>();

builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();

//TODO:Qual o problema?
builder.Services.AddSingleton<IEstoqueRepository, EstoqueRepository>();


//Validaçoes
builder.Services.AddValidatorsFromAssemblyContaining<IncluirDoadorValidator>();
builder.Services.AddMediatR(cfg  => cfg.RegisterServicesFromAssemblyContaining(typeof(CQRSContract)));


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

builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Server=NITRO5\SQLEXPRESS;Database=HangfireBDS;Trusted_Connection=True"));
builder.Services.AddHangfireServer();

var apiKey = builder.Configuration.GetValue<string>("Providers:Sendgrid:ApiKey");
builder.Services.AddSendGrid(options => options.ApiKey = apiKey);   


//Worker
builder.Services.AddHostedService<NotificaBaixaEstoqueWorker>();
builder.Services.AddSingleton<INotificaBaixaEstoqueWorker>(provider => provider.GetRequiredService<NotificaBaixaEstoqueWorker>());


var app = builder.Build();

app.UseHangfireDashboard();

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
