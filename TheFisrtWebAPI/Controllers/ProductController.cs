using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TheFisrtWebAPI.Data;
using TheFisrtWebAPI.Models;

namespace TheFisrtWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProdContext _context;
        public ProductController(ProdContext context)
        {
            _context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProduct()
        {
            var lst = await _context.Product.Select(
                s => new Products
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,

                }).ToListAsync();

            if (lst.Count < 0)
            {

                return NotFound();
            }
            else
            {
                return Ok(lst);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(string id)
        {
            var lst = await _context.Product.Select(
                s => new Products
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                }).FirstOrDefaultAsync(s => s.Id == Guid.Parse(id));
            if (lst == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lst);
            }
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> CreateNewProd(Products prod)
        {
            var p = new Products()
            {
                Id = Guid.NewGuid(),
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
            };
            _context.Product.Add(p);
            await _context.SaveChangesAsync();
            return Ok("Add New Prod Success");
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProd(string id, Products prod)
        {
            if (Guid.Parse(id) != prod.Id)
            {
                return NotFound();
            }
            _context.Entry(prod).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdItemExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return Ok("Update Prod Success");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var prod = await _context.Product.FindAsync(id);
            if (id != prod.Id)
            {
                return NotFound();
            }
            else
            {
                _context.Product.Remove(prod);
                await _context.SaveChangesAsync();
            }
            return Ok("Delete Prod Success");
        }

        private bool ProdItemExists(string id)
        {
            return _context.Product.Any(e => e.Id == Guid.Parse(id));
        }

    }
}
