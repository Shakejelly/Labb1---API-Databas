using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.MenuDto;

namespace Labb1___API_Databas.Repository.MenuRepository
{
    public interface IMenuRepository
    {
        Task AddDishAsync(Menu menu, CancellationToken cancellationToken);
        Task DeleteDish(Menu menu, CancellationToken cancellationToken);
        Task UpdateDish(Menu menu, CancellationToken cancellationToken);
    }
}
