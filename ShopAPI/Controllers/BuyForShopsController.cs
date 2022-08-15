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
    public class BuyForShopsController : ControllerBase
    {
        private readonly ShopContext _context;

        public BuyForShopsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/BuyForShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyForShop>>> GetBuyForShops()
        {
            return await _context.BuyForShops.ToListAsync();
        }

        // GET: api/BuyForShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyForShop>> GetBuyForShop(int id)
        {
            var buyForShop = await _context.BuyForShops.FindAsync(id);

            if (buyForShop == null)
            {
                return NotFound();
            }

            return buyForShop;
        }

        // PUT: api/BuyForShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyForShop(int id, BuyForShop buyForShop)
        {
            if (id != buyForShop.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyForShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyForShopExists(id))
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

        // POST: api/BuyForShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuyForShop>> PostBuyForShop(BuyForShop buyForShop)
        {
            var product = await _context.Products.FindAsync(buyForShop.IdProduct);

            if (product == null)
            {
                return NotFound();
            }

            buyForShop.Product = product;
            buyForShop.Amount = buyForShop.Count * buyForShop.Price;

            _context.BuyForShops.Add(buyForShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyForShop", new { id = buyForShop.Id }, buyForShop);
        }

        // DELETE: api/BuyForShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyForShop(int id)
        {
            var buyForShop = await _context.BuyForShops.FindAsync(id);
            if (buyForShop == null)
            {
                return NotFound();
            }

            _context.BuyForShops.Remove(buyForShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyForShopExists(int id)
        {
            return _context.BuyForShops.Any(e => e.Id == id);
        }
    }
}
