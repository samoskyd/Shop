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
    public class OrdersAndGoodsController : ControllerBase
    {
        private readonly ShopContext _context;

        public OrdersAndGoodsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/OrdersAndGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersAndGoods>>> GetOrdersAndGoods()
        {
            return await _context.OrdersAndGoods.ToListAsync();
        }

        // GET: api/OrdersAndGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersAndGoods>> GetOrdersAndGoods(int id)
        {
            var ordersAndGoods = await _context.OrdersAndGoods.FindAsync(id);

            if (ordersAndGoods == null)
            {
                return NotFound();
            }

            return ordersAndGoods;
        }

        // PUT: api/OrdersAndGoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersAndGoods(int id, OrdersAndGoods ordersAndGoods)
        {
            if (id != ordersAndGoods.OrdersAndGoodsId)
            {
                return BadRequest();
            }

            _context.Entry(ordersAndGoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersAndGoodsExists(id))
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

        // POST: api/OrdersAndGoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersAndGoods>> PostOrdersAndGoods(OrdersAndGoods ordersAndGoods)
        {
            _context.OrdersAndGoods.Add(ordersAndGoods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersAndGoods", new { id = ordersAndGoods.OrdersAndGoodsId }, ordersAndGoods);
        }

        // DELETE: api/OrdersAndGoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersAndGoods(int id)
        {
            var ordersAndGoods = await _context.OrdersAndGoods.FindAsync(id);
            if (ordersAndGoods == null)
            {
                return NotFound();
            }

            _context.OrdersAndGoods.Remove(ordersAndGoods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersAndGoodsExists(int id)
        {
            return _context.OrdersAndGoods.Any(e => e.OrdersAndGoodsId == id);
        }
    }
}
