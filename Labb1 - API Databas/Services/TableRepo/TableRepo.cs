using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.TableRepo
{
    public class TableRepo : ITableRepo
    {
        private readonly RestaurantContext _context;
        public TableRepo(RestaurantContext context)
        {
            _context = context;

        }
        public async Task AddTableAsync(Table table)
        {
            try
            {
                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the table.");
            }
        }
        public async Task DeleteTableAsync(Table Table)
        {
            try
            {
                _context.Tables.Remove(Table);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't delete table.");
            }

        }
    }
}
