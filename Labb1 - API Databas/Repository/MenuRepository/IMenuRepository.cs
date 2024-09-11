using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.MenuDto;

namespace Labb1___API_Databas.Repository.MenuRepository
{
    public interface IMenuRepository
    {
        Task AddDishAsync(Menu menu, CancellationToken cancellationToken);
        Task DeleteDishAsync(Menu menu, CancellationToken cancellationToken);
        Task UpdateDishAsync(Menu menu, CancellationToken cancellationToken);
        Task<IEnumerable<Menu>> GetAllDishesAsync(CancellationToken cancellationToken);
        Task<Menu> MenuGetByIdAsync(int menuId, CancellationToken cancellationToken);
    }
}
