using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.CustomerDto;
using Labb1___API_Databas.Repository.CustomerRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.CustomerRepo
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCustomerAsync(AddCustomerDto customerDto, CancellationToken cancellationToken)
        {
            try
            {
                if (await _repository.CustomerExistAsync(customerDto.PhoneNumber, cancellationToken))
                {
                    return;
                }

                var newCustomer = new Customer
                {
                    ReservationName = customerDto.ReservationName,
                    PhoneNumber = customerDto.PhoneNumber,
                };

                await _repository.AddCustomerAsync(newCustomer, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while adding the customer to the database.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
