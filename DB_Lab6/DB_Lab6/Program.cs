using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Models;

namespace DB_Lab6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            String connection = builder.Configuration.GetConnectionString("MSSQL");
            builder.Services.AddDbContext<PharmacyContext>(options => options.UseSqlServer(connection));
            builder.Services.AddMvc();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.Run();
        }
    }
}