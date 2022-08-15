#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        private readonly ShopContext _context;

        public BuysController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Buys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buy>>> GetBuys()
        {
            return await _context.Buys.ToListAsync();
        }

        // GET: api/Buys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buy>> GetBuy(int id)
        {
            var buy = await _context.Buys.FindAsync(id);

            if (buy == null)
            {
                return NotFound();
            }

            return buy;
        }

        // PUT: api/Buys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuy(int id, Buy buy)
        {
            if (id != buy.Id)
            {
                return BadRequest();
            }

            _context.Entry(buy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyExists(id))
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

        // POST: api/Buys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buy>> PostBuy(Buy buy)
        {
            var product = await _context.Products.FindAsync(buy.IdProduct);

            if (product == null)
            {
                return Problem("Продукт не найден");
            }

            var user = await _context.Users.FindAsync(buy.IdUser);

            if (user == null)
            {
                return Problem("Пользователь не найден");
            }

            if (buy.Count < 0 || buy.Count > product.Count)
            {
                return Problem("Неверно указано количество");
            }

            buy.User = user;
            buy.Product = product;
            buy.Price = product.Price;
            buy.Amount = buy.Count * buy.Price;
            buy.IsFinished = false;

            _context.Buys.Add(buy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuy", new { id = buy.Id }, buy);
        }

        // DELETE: api/Buys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuy(int id)
        {
            var buy = await _context.Buys.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }

            _context.Buys.Remove(buy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyExists(int id)
        {
            return _context.Buys.Any(e => e.Id == id);
        }
    }
}
