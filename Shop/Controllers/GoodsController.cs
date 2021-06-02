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
    public class GoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public GoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goods>>> GetGoods()
        {
            return await _context.Goods.ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goods>> GetGoods(int id)
        {
            var goods = await _context.Goods.FindAsync(id);

            if (goods == null)
            {
                return NotFound();
            }

            return goods;
        }

        // PUT: api/Goods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoods(int id, Goods goods)
        {
            if (id != goods.GoodsId)
            {
                return BadRequest();
            }

            _context.Entry(goods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsExists(id))
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

        // POST: api/Goods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Goods>> PostGoods(Goods goods)
        {
            _context.Goods.Add(goods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoods", new { id = goods.GoodsId }, goods);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoods(int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoodsExists(int id)
        {
            return _context.Goods.Any(e => e.GoodsId == id);
        }
    }
}
