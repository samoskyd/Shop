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
    public class ProvidersAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProvidersAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/ProvidersAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvidersAndGoods>>> GetProvidersAndGoods()
        {
            return await _context.ProvidersAndGoods.ToListAsync();
        }

        // GET: api/ProvidersAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProvidersAndGoods>> GetProvidersAndGoods(int id)
        {
            var providersAndGoods = await _context.ProvidersAndGoods.FindAsync(id);

            if (providersAndGoods == null)
            {
                return NotFound();
            }

            return providersAndGoods;
        }

        // PUT: api/ProvidersAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvidersAndGoods(int id, ProvidersAndGoods providersAndGoods)
        {
            if (id != providersAndGoods.ProvidersAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(providersAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidersAndGoodsExists(id))
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

        // POST: api/ProvidersAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProvidersAndGoods>> PostProvidersAndGoods(ProvidersAndGoods providersAndGoods)
        {
            _context.ProvidersAndGoods.Add(providersAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvidersAndGoods", new { id = providersAndGoods.ProvidersAndGoodsId }, providersAndGoods);
        }

        // DELETE: api/ProvidersAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvidersAndGoods(int id)
        {
            var providersAndGoods = await _context.ProvidersAndGoods.FindAsync(id);
            if (providersAndGoods == null)
            {
                return NotFound();
            }

            _context.ProvidersAndGoods.Remove(providersAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvidersAndGoodsExists(int id)
        {
            return _context.ProvidersAndGoods.Any(e => e.ProvidersAndGoodsId == id);
        }
    }
}
