using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.TableDto;

namespace Labb1___API_Databas.Repositories.TableRepo
{
    public interface ITableService
    {
        Task AddSeatingsAsync(AddTableDto addTableDto, CancellationToken cancellationToken);
        Task UpdateSeatingsAsync(ChangeChairAmountDto changeChairAmountDto, CancellationToken cancellationToken);
        Task<IEnumerable<GetAllTablesDto>> GetAllTablesAsync(CancellationToken cancellationToken);
            }
}
