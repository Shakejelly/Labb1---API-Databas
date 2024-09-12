using Labb1___API_Databas.Data;
using Labb1___API_Databas.Repositories.BookingRepo;
using Labb1___API_Databas.Repositories.CustomerRepo;
using Labb1___API_Databas.Repositories.MenuRepo;
using Labb1___API_Databas.Repositories.TableRepo;
using Labb1___API_Databas.Repository.BookingRepository;
using Labb1___API_Databas.Repository.CustomerRepository;
using Labb1___API_Databas.Repository.MenuRepository;
using Labb1___API_Databas.Repository.TableRepository;
using Labb1___API_Databas.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Labb1___API_Databas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

          
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();

            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
