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
    public class ShopsAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ShopsAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/ShopsAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopsAndGoods>>> GetShopsAndGoods()
        {
            return await _context.ShopsAndGoods.ToListAsync();
        }

        // GET: api/ShopsAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopsAndGoods>> GetShopsAndGoods(int id)
        {
            var shopsAndGoods = await _context.ShopsAndGoods.FindAsync(id);

            if (shopsAndGoods == null)
            {
                return NotFound();
            }

            return shopsAndGoods;
        }

        // PUT: api/ShopsAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopsAndGoods(int id, ShopsAndGoods shopsAndGoods)
        {
            if (id != shopsAndGoods.ShopsAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(shopsAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopsAndGoodsExists(id))
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

        // POST: api/ShopsAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopsAndGoods>> PostShopsAndGoods(ShopsAndGoods shopsAndGoods)
        {
            _context.ShopsAndGoods.Add(shopsAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopsAndGoods", new { id = shopsAndGoods.ShopsAndGoodsId }, shopsAndGoods);
        }

        // DELETE: api/ShopsAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopsAndGoods(int id)
        {
            var shopsAndGoods = await _context.ShopsAndGoods.FindAsync(id);
            if (shopsAndGoods == null)
            {
                return NotFound();
            }

            _context.ShopsAndGoods.Remove(shopsAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopsAndGoodsExists(int id)
        {
            return _context.ShopsAndGoods.Any(e => e.ShopsAndGoodsId == id);
        }
    }
}
