using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using WebAppTest.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=RM96304;Password=220102;Connection Timeout=300;";

        // Criar e abrir a conexão
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Conexão bem-sucedida, execute suas operações de banco de dados aqui
                Console.WriteLine("Conexão bem-sucedida!");

                // Exemplo: Executar uma consulta
                string sqlQuery = "SELECT * FROM t_medico";
                OracleCommand command = new OracleCommand(sqlQuery, connection);

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Processar os resultados
                        // Exemplo: Console.WriteLine(reader["nome_da_coluna"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=RM96304;Password=220102; ";
        //string connectionString = "Data Source=oracle.fiap.com.br:1521/ORCL;"
        //               + "User Id=RM95932;Password=070202;"
        //               + "Connection Timeout=60;";
        //builder.Services.AddDbContext<Contexto>(options => options.UseOracle(connectionString));

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