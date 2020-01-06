using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aruba.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslandsController : ControllerBase
    {
        private readonly IslandDbContext context;

        public IslandsController(IslandDbContext context)
        {
            this.context = context;
        }

        // GET: api/Islands
        [HttpGet]
        public IEnumerable<Island> GetIslands()
        {
            return context.Islands;
        }

		// GET: api/Islands/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetIsland([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var island = await context.Islands.FindAsync(id);

			if (island == null)
			{
				return NotFound();
			}

			return Ok(island);
		}

		// PUT: api/Islands/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutIsland([FromRoute] int id, [FromBody] Island island)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != island.Id)
			{
				return BadRequest();
			}

			context.Entry(island).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!IslandExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Restaurants
		[HttpPost]
		public async Task<IActionResult> PostIsland([FromBody] Island island)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			context.Islands.Add(island);
			await context.SaveChangesAsync();

			return CreatedAtAction("GetIsland", new { id = island.Id }, island);
		}

		// DELETE: api/Restaurants/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteIsland([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var island = await context.Islands.FindAsync(id);
			if (island == null)
			{
				return NotFound();
			}

			context.Islands.Remove(island);
			await context.SaveChangesAsync();

			return Ok(island);
		}

		private bool IslandExists(int id)
		{
			return context.Islands.Any(e => e.Id == id);
		}

	}

}