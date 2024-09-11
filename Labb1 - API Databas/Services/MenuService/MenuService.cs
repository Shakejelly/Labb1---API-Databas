using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.MenuDto;
using Labb1___API_Databas.Repositories.MenuRepo;
using Labb1___API_Databas.Repository.MenuRepository;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Services
{
    public class MenuService : IMenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task AddMenuAsync(AddDishDto addDishDto, CancellationToken cancellationToken)
        {
            try
            {
                var newDish = new Menu
                {
                    DishName = addDishDto.DishName,
                    Description = addDishDto.Description,
                    DishPrice = addDishDto.DishPrice,
                };
                await _menuRepository.AddDishAsync(newDish, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while adding the dish to the database.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred while adding the dish.", ex);
            }
        }

        public async Task ChangeAvaiableDishAsync(UpdateDishInStockDto updateDishInStockDto, CancellationToken cancellationToken)
        {
            try
            {
                var menuFound = await _menuRepository.MenuGetByIdAsync(updateDishInStockDto.DishId, cancellationToken);

                if (menuFound == null)
                {
                    throw new Exception($"Dish with ID {updateDishInStockDto.DishId} not found.");
                }

                menuFound.DishInStock = updateDishInStockDto.DishAvailable;

                await _menuRepository.UpdateDishAsync(menuFound, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while updating the dish stock status.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred while updating the dish stock status.", ex);
            }
        }

        public async Task<IEnumerable<GetMenuDto>> GetAllMenuAsync(CancellationToken cancellationToken)
        {
            try
            {
                var menu = await _menuRepository.GetAllDishesAsync(cancellationToken);

                return menu.Select(x => new GetMenuDto
                {
                    DishName = x.DishName,
                    Description = x.Description,
                    DishPrice = x.DishPrice,
                }).ToList();
            }
            catch (Exception ex)
            {
                // Logga eller hantera andra typer av fel
                throw new Exception("An error occurred while retrieving the menu.", ex);
            }
        }

        public async Task UpdateMenuAsync(UpdateDishDto updateDishDto, CancellationToken cancellationToken)
        {
            try
            {
                var menuFound = await _menuRepository.MenuGetByIdAsync(updateDishDto.DishId, cancellationToken);

                if (menuFound == null)
                {
                    throw new Exception($"Dish with ID {updateDishDto.DishId} not found.");
                }

                menuFound.DishPrice = updateDishDto.DishPrice;

                await _menuRepository.UpdateDishAsync(menuFound, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while updating the dish.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred while updating the dish.", ex);
            }
        }
    }
}
