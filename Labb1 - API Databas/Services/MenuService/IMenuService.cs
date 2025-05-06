using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.MenuDto;

namespace Labb1___API_Databas.Repositories.MenuRepo
{
    public interface IMenuService
    {
        Task AddMenuAsync(AddDishDto addDishDto, CancellationToken cancellationToken);
        Task UpdateMenuAsync(UpdateDishDto updateDishDto, CancellationToken cancellationToken);
        Task ChangeAvaiableDishAsync(UpdateDishInStockDto updateDishInStock, CancellationToken cancellationToken);
        Task<IEnumerable<GetMenuDto>> GetAllMenuAsync(CancellationToken cancellationToken);
        Task DeleteDishAsync(int dishId, CancellationToken cancellationToken);
        Task<Menu?> GetDishByIdAsync(int id, CancellationToken cancellationToken);


    }
}
