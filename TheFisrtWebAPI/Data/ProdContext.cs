using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TheFisrtWebAPI.Models;

namespace TheFisrtWebAPI.Data
{
    public class ProdContext : DbContext
    {
        
        public ProdContext(DbContextOptions<ProdContext> options) : base(options) { }

        public DbSet<Products> Product { get; set; }
        public DbSet<Categories> Category { get; set; }
    }
}
