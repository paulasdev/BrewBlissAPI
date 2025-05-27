using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewBlissInfo.Models;

namespace BrewBlissInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryInfoController : ControllerBase
    {
        private readonly BrewBlissInfoDbContext _context;

        public CategoryInfoController(BrewBlissInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryInfo>>> GetAll()
        {
            return await _context.CategoryInfos.ToListAsync();
        }

        // GET: api/CategoryInfo/
        [HttpGet("{name}")]
        public async Task<ActionResult<CategoryInfo>> GetByName(string name)
        {
            var category = await _context.CategoryInfos
                .FirstOrDefaultAsync(c => c.CategoryInfoName == name);

            if (category == null)
                return NotFound();

            return category;
        }
    }
}