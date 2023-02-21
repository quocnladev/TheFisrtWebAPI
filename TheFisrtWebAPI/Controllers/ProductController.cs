using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
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

        /*// GET: api/<ProductController>
        [HttpGet("GetProduct")]
        public async Task<ActionResult<List<Products>>> GetProduct()
        {
            var List = await _context.Product.Select(
                s => new Products
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,

                }).ToListAsync();

            if (List.Count < 0)
            {

                return NotFound();
            }
            else
            {
                return Ok(List);
            }
        }*/

        /*// GET api/<ProductController>/5
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<Products>> GetProductById(int id)
        {
            var List = await _context.Product.Select(
                s => new Products
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                }).FirstOrDefaultAsync(s => s.Id == id);
            if (List == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(List);
            }
        }
        */

        // POST api/<ProductController>
        [HttpPost("CreateNewProd")]
        public async Task<IActionResult> CreateNewProd(Products prod)
        {
            var p = new Products()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
            };
            _context.Product.Add(p);
            await _context.SaveChangesAsync();
            return Ok("Add New Prod Success");
        }


        // PUT api/<ProductController>/5
        [HttpPut("UpdateProd/{id}")]
        public async Task<IActionResult> UpdateProd(int id, Products prod)
        {
            if (id != prod.Id)
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
        [HttpDelete("DeleteProd/{id}")]
        public async Task<IActionResult> Delete(int id)
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


        //GET: api/Product
        [HttpGet("GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProduct()
        {
            return await _context.Product
                .Select(s => productDTO(s))
            .ToListAsync();
        }

        //GET ID: api/Product/{id}
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ProductsDTO>> GetProductById(int id)
        {
            var prod = await _context.Product.FindAsync(id);

            if (prod == null)
            {
                return NotFound();
            }
            return productDTO(prod);
        }

        /* //POST: api/Product - MUST TO SET DESCRIPTION IS NULL
        [HttpPost("CreateNewProd")]
        public async Task<ActionResult<ProductsDTO>> CreateNewProd(ProductsDTO prodDTO)
        {
            var prod = new Products
            {
                //Id = prodDTO.Id,
                Name = prodDTO.Name,
                Price = prodDTO.Price
            };

            _context.Product.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = prod.Id },
                productDTO(prod));
        }*/

        /*//PUT: api/Product - MUST TO SET DESCRIPTION IS NULL
        [HttpPut("UpdateProd/{id}")]
        public async Task<ActionResult<ProductsDTO>> UpdateProd(int id, ProductsDTO prodDTO)
        {   
            if(id != prodDTO.Id)
            {
                return NotFound();
            }

            var prod = await _context.Product.FindAsync(id);
            if(prod == null)
            {
                return NotFound();
            }

            prod.Name = prodDTO.Name;
            prod.Price = prodDTO.Price;

            try
            {
                await async _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException) when (!ProdItemExists(id))
            {
                return NotFound();
            }
            return Ok("Update Prod Success");
            
        }*/


        private bool ProdItemExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        private static ProductsDTO productDTO(Products product) => new ProductsDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}
