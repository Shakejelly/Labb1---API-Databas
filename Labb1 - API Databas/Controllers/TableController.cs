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
    }
}
