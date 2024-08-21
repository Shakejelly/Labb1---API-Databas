using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base (options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
