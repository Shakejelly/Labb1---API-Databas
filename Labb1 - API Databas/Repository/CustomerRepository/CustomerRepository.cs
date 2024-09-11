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
            try
            {
                await _context.Customers.AddAsync(customer, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while adding the customer.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public Task<bool> CustomerExistAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            try
            {
                return _context.Customers.AnyAsync(p => p.PhoneNumber == phoneNumber, cancellationToken);
            }
            catch (Exception ex)
            {
                // Hantera fel vid kontroll av kundens existens
                throw new Exception("An error occurred while checking if the customer exists.", ex);
            }

        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);

                if (customer == null)
                {
                    throw new Exception($"Customer with ID {customerId} not found.");
                }

                return customer;
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av kund
                throw new Exception("An error occurred while retrieving the customer.", ex);
            }
        }

  
    }
}
