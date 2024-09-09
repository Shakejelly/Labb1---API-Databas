using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.CustomerRepo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly RestaurantContext _context;
        public CustomerRepo(RestaurantContext context)
        {
            _context = context;

        }
        public async Task AddCustomerAsync(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the customer.");
            }
        }
        public async Task DeleteCustomerAsync(Customer Customer)
        {
            try
            {
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't delete customer.");
            }

        }


    }
}
