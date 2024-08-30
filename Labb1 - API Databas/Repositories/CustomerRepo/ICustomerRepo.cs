using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.CustomerRepo
{
    public interface ICustomerRepo
    {
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
