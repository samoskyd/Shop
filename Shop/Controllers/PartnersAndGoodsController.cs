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
    public class PartnersAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public PartnersAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/PartnersAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnersAndGoods>>> GetPartnersAndGoods()
        {
            return await _context.PartnersAndGoods.ToListAsync();
        }

        // GET: api/PartnersAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartnersAndGoods>> GetPartnersAndGoods(int id)
        {
            var partnersAndGoods = await _context.PartnersAndGoods.FindAsync(id);

            if (partnersAndGoods == null)
            {
                return NotFound();
            }

            return partnersAndGoods;
        }

        // PUT: api/PartnersAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnersAndGoods(int id, PartnersAndGoods partnersAndGoods)
        {
            if (id != partnersAndGoods.PartnersAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(partnersAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnersAndGoodsExists(id))
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

        // POST: api/PartnersAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartnersAndGoods>> PostPartnersAndGoods(PartnersAndGoods partnersAndGoods)
        {
            _context.PartnersAndGoods.Add(partnersAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartnersAndGoods", new { id = partnersAndGoods.PartnersAndGoodsId }, partnersAndGoods);
        }

        // DELETE: api/PartnersAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnersAndGoods(int id)
        {
            var partnersAndGoods = await _context.PartnersAndGoods.FindAsync(id);
            if (partnersAndGoods == null)
            {
                return NotFound();
            }

            _context.PartnersAndGoods.Remove(partnersAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnersAndGoodsExists(int id)
        {
            return _context.PartnersAndGoods.Any(e => e.PartnersAndGoodsId == id);
        }
    }
}
