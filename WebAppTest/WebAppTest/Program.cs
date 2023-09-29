using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using WebAppTest.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "User Id=RM96304;Password=220102;Data Source=oracle.fiap.com.br:1521/ORCL;Connection Timeout=60;";

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<Contexto>(options => options.UseOracle(connectionString).EnableSensitiveDataLogging(true));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}