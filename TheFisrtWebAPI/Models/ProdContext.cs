using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TheFisrtWebAPI.Models
{
    public class ProdContext : DbContext
    {
        public DbSet<Products> Product { get; set; } = null!;
        public ProdContext(DbContextOptions<ProdContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }*/
        }
    }
}
