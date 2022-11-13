using RpgApi.Data; //chamando o NameSpace
using Microsoft.EntityFrameworkCore; //Entity para SQLSERVER
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSomee")); //no ConexaoLocal é onde eu escolho o banco de dados
});
//Comando para criar o script - dotnet ef migrations script -o ./script01_TabelaPersonagens.sql
//Comando para publicar a API - dotnet publish -c release -o ./publish
//Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
