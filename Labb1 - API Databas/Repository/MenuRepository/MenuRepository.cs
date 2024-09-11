using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repository.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantContext _context;

        public MenuRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddDishAsync(Menu menu, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Menus.AddAsync(menu, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while adding the dish.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task DeleteDishAsync(Menu menu, CancellationToken cancellationToken)
        {
            try
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while deleting the dish.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task<IEnumerable<Menu>> GetAllDishesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Menus
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av alla rätter
                throw new Exception("An error occurred while retrieving dishes.", ex);
            }
        }

        public async Task<Menu> MenuGetByIdAsync(int menuId, CancellationToken cancellationToken)
        {
            try
            {
                var menu = await _context.Menus
                    .FirstOrDefaultAsync(m => m.DishId == menuId, cancellationToken);

                if (menu == null)
                {
                    throw new Exception($"Dish with ID {menuId} not found.");
                }

                return menu;
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av specifik rätt
                throw new Exception("An error occurred while retrieving the dish.", ex);
            }
        }

        public async Task UpdateDishAsync(Menu menu, CancellationToken cancellationToken)
        {
            try
            {
                _context.Menus.Update(menu);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera felet på ett passande sätt
                throw new Exception("An error occurred while updating the dish.", ex);
            }
            catch (Exception ex)
            {
                // Hantera generella fel
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
