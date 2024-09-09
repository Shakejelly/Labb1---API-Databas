using Labb1___API_Databas.Models.Dto.CustomerDto;

namespace Labb1___API_Databas.Repositories.CustomerRepo
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(AddCustomerDto addCustomer, CancellationToken cancellationToken);

    }
}
