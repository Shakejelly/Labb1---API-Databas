using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Models.Dto.MenuDto;
using Labb1___API_Databas.Models.Dto.TableDto;
using Labb1___API_Databas.Repositories.TableRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableRepo;
        public TableController(ITableService tableRepo)
        {
            _tableRepo = tableRepo;            
        }
        [HttpGet]
        [Route("getAllTables")]
        public async Task<IActionResult> GetAllTables(CancellationToken cancellationToken)
        {
            try
            {
                var table = await _tableRepo.GetAllTablesAsync(cancellationToken);
                return Ok(table);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving tables.");
            }
        }
        [HttpPost]
        [Route("addTables")]
        public async Task<IActionResult> AddTables(AddTableDto addTableDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _tableRepo.AddSeatingsAsync(addTableDto, cancellationToken);


                return StatusCode(200, "added table");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
        [HttpPut]
        [Route("updateTables/{TableId}")]
        public async Task<IActionResult> UpdateTable(int tableId, ChangeChairAmountDto changeChairAmountDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                changeChairAmountDto.SeatingAmount = tableId;
                await _tableRepo.UpdateSeatingsAsync(changeChairAmountDto, cancellationToken);
                return NoContent(); // Indicate success without returning data
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred while updating the booking.");
            }
        }
    }
}
