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
    public class InfluencersAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public InfluencersAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/InfluencersAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfluencersAndGoods>>> GetInfluencersAndGoods()
        {
            return await _context.InfluencersAndGoods.ToListAsync();
        }

        // GET: api/InfluencersAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfluencersAndGoods>> GetInfluencersAndGoods(int id)
        {
            var influencersAndGoods = await _context.InfluencersAndGoods.FindAsync(id);

            if (influencersAndGoods == null)
            {
                return NotFound();
            }

            return influencersAndGoods;
        }

        // PUT: api/InfluencersAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfluencersAndGoods(int id, InfluencersAndGoods influencersAndGoods)
        {
            if (id != influencersAndGoods.InfluencersAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(influencersAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfluencersAndGoodsExists(id))
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

        // POST: api/InfluencersAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfluencersAndGoods>> PostInfluencersAndGoods(InfluencersAndGoods influencersAndGoods)
        {
            _context.InfluencersAndGoods.Add(influencersAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfluencersAndGoods", new { id = influencersAndGoods.InfluencersAndGoodsId }, influencersAndGoods);
        }

        // DELETE: api/InfluencersAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfluencersAndGoods(int id)
        {
            var influencersAndGoods = await _context.InfluencersAndGoods.FindAsync(id);
            if (influencersAndGoods == null)
            {
                return NotFound();
            }

            _context.InfluencersAndGoods.Remove(influencersAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfluencersAndGoodsExists(int id)
        {
            return _context.InfluencersAndGoods.Any(e => e.InfluencersAndGoodsId == id);
        }
    }
}
