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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

            builder.Services.AddCors(options => 
            {
                options.AddPolicy("LocalReact", policy =>
                {
                    policy.WithOrigins("http://localhost:5173/")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
            builder.Services.AddAuthorization();

          
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("LocalReact");

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
