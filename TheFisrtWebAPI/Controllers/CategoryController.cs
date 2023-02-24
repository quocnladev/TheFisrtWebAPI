using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TheFisrtWebAPI.Data;
using TheFisrtWebAPI.Models;

namespace TheFisrtWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly ProdContext _context;
        public CategoryController(ProdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ct = _context.Category.ToList();
            return Ok(ct);
        }

        [HttpPost]
        public IActionResult CreateCate(Categories cate)
        {
            var ct = new Categories
            {
                CateID= Guid.NewGuid(),
                CateName = cate.CateName
            };

            _context.Category.Add(ct);
            _context.SaveChanges();

            return Ok(new
            {
                Success = true,
                Data = ct
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id) { 
            var ct = _context.Category.SingleOrDefault(x => x.CateID==id);
            if(ct == null)
            {
                return NotFound();
            }
            return Ok(ct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCate(Categories cate, Guid id) {
            var ct = _context.Category.SingleOrDefault(x => x.CateID == id);
            if(ct == null)
            {
                return NotFound();
            }

            else
            {
                ct.CateName = cate.CateName;
            }
            
            _context.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data= ct
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            var ct = _context.Category.SingleOrDefault(x => x.CateID==id);

            if(ct == null)
            {
                return NotFound();
            }

            _context.Category.Remove(ct);
            _context.SaveChanges();
            return Ok(200);
        }

    }
}
