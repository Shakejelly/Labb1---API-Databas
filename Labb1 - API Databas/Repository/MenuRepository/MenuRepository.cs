using Labb1___API_Databas.Data;

namespace Labb1___API_Databas.Repository.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantContext _context;

        public MenuRepository(RestaurantContext context)
        {
            _context = context;
        }
    }
}
