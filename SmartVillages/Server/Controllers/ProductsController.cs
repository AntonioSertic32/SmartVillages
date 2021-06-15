using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartVillages.Server.Data;
using SmartVillages.Shared.MarketplaceModels;

namespace SmartVillages.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProduct(Product product)
        {
            var image = await _context.ProductImages.SingleOrDefaultAsync(t => t.Id == product.ProductImage.Id);
            product.ProductImage = image;

            var category = await _context.ProductCategorys.SingleOrDefaultAsync(t => t.Species == product.ProductCategory.Species);
            product.ProductCategory = category;

            var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == product.User.Id);
            product.User = user;

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var image = await _context.ProductImages.SingleOrDefaultAsync(t => t.Id == product.ProductImage.Id);
            product.ProductImage = image;

            var category = await _context.ProductCategorys.SingleOrDefaultAsync(t => t.Species == product.ProductCategory.Species);
            product.ProductCategory = category;

            var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == product.User.Id);
            product.User = user;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            product.Deleted = true;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


        [HttpGet("getlastten")]
        public async Task<ActionResult<List<Product>>> GeTLastTen()
        {
            List<Product> products = new List<Product>();
            products = _context.Products.Where(p => p.Deleted != true).OrderByDescending(t => t.Id).Include(f => f.User).Include(f => f.User.UserImage).Include(f => f.User.Place).Include(f => f.ProductCategory).Include(i => i.ProductImage).Take(10).ToList();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return products;
            }
        }
    }
}
