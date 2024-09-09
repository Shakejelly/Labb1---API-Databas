using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
        Task<Customer> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken);
        Task<bool> CustomerExistAsync(string phoneNumber, CancellationToken cancellationToken);
    }
}
