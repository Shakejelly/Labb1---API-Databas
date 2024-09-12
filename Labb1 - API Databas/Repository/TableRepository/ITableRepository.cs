using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repository.TableRepository
{
    public interface ITableRepository
    {
        Task AddTableAsync(Table table, CancellationToken cancellationToken);
        Task UpdateTableAsync(Table table, CancellationToken cancellationToken);
        Task<IEnumerable<Table>> GetAllTablesAsync(CancellationToken cancellationToken);
        Task<Table> GetTableByIdAsync(int id, CancellationToken cancellationToken);
    }
}
