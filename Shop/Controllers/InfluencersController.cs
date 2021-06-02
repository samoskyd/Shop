using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencersController : ControllerBase
    {
        private readonly ShopContext _context;

        public InfluencersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Influencers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Influencers>>> GetInfluencers()
        {
            return await _context.Influencers.ToListAsync();
        }

        // GET: api/Influencers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Influencers>> GetInfluencers(int id)
        {
            var influencers = await _context.Influencers.FindAsync(id);

            if (influencers == null)
            {
                return NotFound();
            }

            return influencers;
        }

        // PUT: api/Influencers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfluencers(int id, Influencers influencers)
        {
            if (id != influencers.InfluencersId)
            {
                return BadRequest();
            }

            _context.Entry(influencers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfluencersExists(id))
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

        // POST: api/Influencers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Influencers>> PostInfluencers(Influencers influencers)
        {
            _context.Influencers.Add(influencers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfluencers", new { id = influencers.InfluencersId }, influencers);
        }

        // DELETE: api/Influencers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfluencers(int id)
        {
            var influencers = await _context.Influencers.FindAsync(id);
            if (influencers == null)
            {
                return NotFound();
            }

            _context.Influencers.Remove(influencers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfluencersExists(int id)
        {
            return _context.Influencers.Any(e => e.InfluencersId == id);
        }
    }
}
