
using EmpApp.BL.Interfaces;
using EmpApp.BL.Services;
using EmpApp.DataAccess;
using EmpApp.DataAccess.Interfaces;
using EmpApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            //builder.Services.AddScoped<IEmployeeService, EmployeeService>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Add DbContext with PostgreSQL
            builder.Services.AddDbContext<NgIpfDBContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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
