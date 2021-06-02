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
    public class EmployersController : ControllerBase
    {
        private readonly ShopContext _context;

        public EmployersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Employers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employers>>> GetEmployers()
        {
            return await _context.Employers.ToListAsync();
        }

        // GET: api/Employers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employers>> GetEmployers(int id)
        {
            var employers = await _context.Employers.FindAsync(id);

            if (employers == null)
            {
                return NotFound();
            }

            return employers;
        }

        // PUT: api/Employers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployers(int id, Employers employers)
        {
            if (id != employers.EmployersId)
            {
                return BadRequest();
            }

            _context.Entry(employers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployersExists(id))
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

        // POST: api/Employers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employers>> PostEmployers(Employers employers)
        {
            _context.Employers.Add(employers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployers", new { id = employers.EmployersId }, employers);
        }

        // DELETE: api/Employers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployers(int id)
        {
            var employers = await _context.Employers.FindAsync(id);
            if (employers == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(employers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployersExists(int id)
        {
            return _context.Employers.Any(e => e.EmployersId == id);
        }
    }
}
