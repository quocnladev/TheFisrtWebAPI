using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TheFisrtWebAPI.Models
{
    public class ProdContext : DbContext
    {
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

        public DbSet<Products> Product{ get; set; } = null!; 
    }
}
