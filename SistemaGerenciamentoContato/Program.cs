
using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoContato.Data;
using SistemaGerenciamentoContato.Interface;
using SistemaGerenciamentoContato.Repositories;

namespace SistemaGerenciamentoContato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
           .AddDbContext<SistemaGerenciamentoContatoDbContext>(
                   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
               );

            builder.Services.AddScoped<IContatoRepositories, ContatoRepositories>();
            builder.Services.AddScoped<IItemRepositories, ItemRepositories>();

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
        }
    }
}
