using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.TableRepo
{
    public interface ITableRepo
    {
        Task AddTableAsync(Table table);
        Task DeleteTableAsync(Table table);

    }
}
