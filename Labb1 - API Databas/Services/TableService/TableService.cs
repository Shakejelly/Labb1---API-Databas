using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.MenuDto;
using Labb1___API_Databas.Models.Dto.TableDto;
using Labb1___API_Databas.Repository.TableRepository;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.TableRepo
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly RestaurantContext _context;
        public TableService(ITableRepository tableRepository, RestaurantContext restaurantContext)
        {
            _tableRepository = tableRepository;
            _context = restaurantContext;
        }

        public async Task AddSeatingsAsync(AddTableDto addTableDto, CancellationToken cancellationToken)
        {
            try
            {
                var newTable = new Table
                {
                    Seatings = addTableDto.SeatingAmount
                };
                await _tableRepository.AddTableAsync(newTable, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while adding the table to the database.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred while adding the dish.", ex);
            }
        }


        public async Task<IEnumerable<GetAllTablesDto>> GetAllTablesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var table = await _tableRepository.GetAllTablesAsync(cancellationToken);
    
               return table.Select(x => new GetAllTablesDto
               {
                  Id = x.TableId,
                  SeatingAmount = x.Seatings
               }).ToList();
            }
            catch (Exception ex)
            {
                // Logga eller hantera andra typer av fel
                throw new Exception("An error occurred while retrieving the menu.", ex);
            }


        }


        public async Task<Table?> GetAvailableTableAsync(int seatingsRequired, DateTime bookingTime, CancellationToken cancellationToken)
        {
            var availableTable = await _context.Tables
                .Include(t => t.Bookings)
                .Where(t => t.Seatings >= seatingsRequired && !t.Bookings.Any(b => b.TimeToArrive == bookingTime))
                .FirstOrDefaultAsync(cancellationToken);

            return availableTable;
        }



        public async Task UpdateSeatingsAsync(ChangeChairAmountDto changeChairAmountDto, CancellationToken cancellationToken)
        {
            try
            {
                var tableFound = await _tableRepository.GetTableByIdAsync(changeChairAmountDto.TableId, cancellationToken);

                if (tableFound == null)
                {
                    throw new Exception($"Table not found.");
                }

                tableFound.Seatings = changeChairAmountDto.SeatingAmount;

                await _tableRepository.UpdateTableAsync(tableFound, cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Logga eller hantera databasfel
                throw new Exception("An error occurred while updating the table.", ex);
            }
            catch (Exception ex)
            {
                // Hantera andra typer av fel
                throw new Exception("An unexpected error occurred while updating the table.", ex);
            }
        }
    } }
    

