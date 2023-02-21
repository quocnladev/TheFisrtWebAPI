using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheFisrtWebAPI.Models;

namespace TheFisrtWebAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProdContext _context;

        public  ProductController (ProdContext context)
        {
            _context = context;
        }
        // GET: api/<ProductController>
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

            if(List.Count < 0)
            {
                
                return NotFound();
            }
            else
            {
                return Ok(List);
            }
        }

        /*// GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] string value)
        {

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
