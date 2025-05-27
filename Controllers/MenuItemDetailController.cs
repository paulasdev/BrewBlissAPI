using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewBlissInfo.Models;

namespace BrewBlissInfo.Controllers
{
    [Route("api/GetMenuItem")]
    [ApiController]
    public class MenuItemApiController : ControllerBase
    {
        private readonly BrewBlissInfoDbContext _context;

        public MenuItemApiController(BrewBlissInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/GetMenuItem/{name}
        [HttpGet("{name}")]
        public async Task<IActionResult> GetMenuItem(string name)
        {
            var item = await _context.MenuItemDetails
                .FirstOrDefaultAsync(m => m.NameItem == name);

            if (item == null)
                return NotFound();

            return Ok(new
            {
                item.Ingredients,
                item.Calories,
                item.Vegan
            });
        }
    }
}