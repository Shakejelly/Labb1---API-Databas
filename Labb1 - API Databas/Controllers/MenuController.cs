using Labb1___API_Databas.Repositories.MenuRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuRepo;
        public MenuController(IMenuService menuRepo)
        {
            _menuRepo = menuRepo;
        }
    }
}
