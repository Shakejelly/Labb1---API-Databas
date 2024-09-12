using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Labb1___API_Databas.Repository.TableRepository
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantContext _context;
        public TableRepository(RestaurantContext context)
        {

            _context = context;

        }

        public async Task AddTableAsync(Table table, CancellationToken cancellationToken)
        {
            try
            {
             _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
              
                throw new Exception("An error occurred while adding the table.", ex);
            }
            catch (Exception ex)
            {
                
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Tables
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av bokningar
                throw new Exception("An error occurred while retrieving bookings.", ex);
            }

        }

        public async Task<Table> GetTableByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var table = await _context.Tables
                    .FirstOrDefaultAsync(m => m.TableId == id, cancellationToken);

                if (table == null)
                {
                    throw new Exception($"Table with ID {id} not found.");
                }

                return table;
            }
            catch (Exception ex)
            {
                // Hantera fel vid hämtning av specifik rätt
                throw new Exception("An error occurred while retrieving the dish.", ex);
            }
        }

        public async Task UpdateTableAsync(Table table, CancellationToken cancellationToken)
        {
            try
            {
                 await _context.Tables.AddAsync(table, cancellationToken);
                 await _context.SaveChangesAsync(cancellationToken);

            }
            catch (DbUpdateException ex)
            {

                throw new Exception("An error occurred while adding the table.", ex);
            }
            catch (Exception ex)
            {

                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
