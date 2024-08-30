using Labb1___API_Databas.Models;

namespace Labb1___API_Databas.Repositories.MenuRepo
{
    public interface IMenuRepo
    {
        Task AddMenuAsync(Menu menu);
    }
}
