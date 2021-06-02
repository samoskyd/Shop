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
    public class EmployersAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public EmployersAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/EmployersAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployersAndGoods>>> GetEmployersAndGoods()
        {
            return await _context.EmployersAndGoods.ToListAsync();
        }

        // GET: api/EmployersAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployersAndGoods>> GetEmployersAndGoods(int id)
        {
            var employersAndGoods = await _context.EmployersAndGoods.FindAsync(id);

            if (employersAndGoods == null)
            {
                return NotFound();
            }

            return employersAndGoods;
        }

        // PUT: api/EmployersAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployersAndGoods(int id, EmployersAndGoods employersAndGoods)
        {
            if (id != employersAndGoods.EmployersAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(employersAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployersAndGoodsExists(id))
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

        // POST: api/EmployersAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployersAndGoods>> PostEmployersAndGoods(EmployersAndGoods employersAndGoods)
        {
            _context.EmployersAndGoods.Add(employersAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployersAndGoods", new { id = employersAndGoods.EmployersAndGoodsId }, employersAndGoods);
        }

        // DELETE: api/EmployersAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployersAndGoods(int id)
        {
            var employersAndGoods = await _context.EmployersAndGoods.FindAsync(id);
            if (employersAndGoods == null)
            {
                return NotFound();
            }

            _context.EmployersAndGoods.Remove(employersAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployersAndGoodsExists(int id)
        {
            return _context.EmployersAndGoods.Any(e => e.EmployersAndGoodsId == id);
        }
    }
}
