using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
               
                  new Customer { CustomerId = 1, ReservationName = "John Doe", PhoneNumber = "(555) 123 - 4567" },
                  new Customer { CustomerId = 2, ReservationName = "Jane Smith", PhoneNumber = "(555) 234-5678" },
                  new Customer { CustomerId = 3, ReservationName = "Michael Johnson", PhoneNumber = "(555) 345-6789" }

                );
            modelBuilder.Entity<Table>().HasData(
                
                new Table { TableNumber = 1, Seatings = 2 },
                new Table { TableNumber = 2, Seatings = 2 },
                new Table { TableNumber = 3, Seatings = 2 },
                new Table { TableNumber = 4, Seatings = 4 },
                new Table { TableNumber = 5, Seatings = 4 },
                new Table { TableNumber = 6, Seatings = 4 },
                new Table { TableNumber = 7, Seatings = 4 },
                new Table { TableNumber = 8, Seatings = 6 },
                new Table { TableNumber = 9, Seatings = 6 },
                new Table { TableNumber = 10, Seatings = 6 },
                new Table { TableNumber = 11, Seatings = 6 },
                new Table { TableNumber = 12, Seatings = 10 },
                new Table { TableNumber = 13, Seatings = 10 }
                );
            modelBuilder.Entity<Menu>().HasData(

                new Menu { DishId = 1, DishName = "Spaghetti Carbonara", Description = "Classic Italian pasta with a creamy egg and pancetta sauce.", DishPrice = 14.99 },
                new Menu { DishId = 2, DishName = "Margherita Pizza", Description = "A simple pizza topped with fresh tomatoes, mozzarella, and basil.", DishPrice = 12.50 },
                new Menu { DishId = 3, DishName = "Chicken Tikka Masala", Description = "Tender chicken in a spiced tomato and cream sauce, served with rice.", DishPrice = 16.99 },
                new Menu { DishId = 4, DishName = "Sushi Platter", Description = "An assortment of fresh sushi rolls with wasabi and soy sauce.", DishPrice = 22.00 },
                new Menu { DishId = 5, DishName = "Caesar Salad", Description = "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan.", DishPrice = 10.50 },
                new Menu { DishId = 6, DishName = "Beef Tacos", Description = "Soft tortillas filled with seasoned beef, lettuce, and cheddar cheese.", DishPrice = 11.25 },
                new Menu { DishId = 7, DishName = "Pad Thai", Description = "Stir-fried rice noodles with shrimp, peanuts, and tangy tamarind sauce.", DishPrice = 13.75 },
                new Menu { DishId = 8, DishName = "Lobster Bisque", Description = "Rich and creamy soup made from fresh lobster and a touch of sherry.", DishPrice = 18.50 },
                new Menu { DishId = 9, DishName = "Veggie Stir-Fry", Description = "A colorful mix of vegetables sautéed in a savory soy-ginger sauce.", DishPrice = 12.00 },
                new Menu { DishId = 10, DishName = "Chocolate Lava Cake", Description = "Warm, molten-centered chocolate cake served with vanilla ice cream.", DishPrice = 8.99 }

                );
        }

    }
}
