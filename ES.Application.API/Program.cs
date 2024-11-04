using ES.Application.API.Configurations;
using ES.Infra.API.Context;
//using ES.Services.API.FilterMessage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;

// Add services to the container.

builder.Services.ConfigureServices();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EstoqueContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ES.Infra.API")));

builder.Services.AddDatabase(_configuration);

builder.Services.AddDatabase(_configuration);
builder.Services.AddRepositories();

// Adicione seus serviços e configurações aqui
builder.Services.AddServices(_configuration);

builder.Services.AddCors(_configuration);

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
