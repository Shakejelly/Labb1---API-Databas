using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantContext _context;

        public CustomerRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public Task<bool> CustomerExistAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            return _context.Customers.AnyAsync(p => p.PhoneNumber == phoneNumber, cancellationToken);

            
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);

                return customer;
        }

  
    }
}
