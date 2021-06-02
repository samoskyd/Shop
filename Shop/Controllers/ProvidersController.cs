﻿using System;
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
    public class ProvidersController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProvidersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Providers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Providers>>> GetProviders()
        {
            return await _context.Providers.ToListAsync();
        }

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Providers>> GetProviders(int id)
        {
            var providers = await _context.Providers.FindAsync(id);

            if (providers == null)
            {
                return NotFound();
            }

            return providers;
        }

        // PUT: api/Providers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProviders(int id, Providers providers)
        {
            if (id != providers.ProvidersId)
            {
                return BadRequest();
            }

            _context.Entry(providers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidersExists(id))
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

        // POST: api/Providers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Providers>> PostProviders(Providers providers)
        {
            _context.Providers.Add(providers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProviders", new { id = providers.ProvidersId }, providers);
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProviders(int id)
        {
            var providers = await _context.Providers.FindAsync(id);
            if (providers == null)
            {
                return NotFound();
            }

            _context.Providers.Remove(providers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvidersExists(int id)
        {
            return _context.Providers.Any(e => e.ProvidersId == id);
        }
    }
}
