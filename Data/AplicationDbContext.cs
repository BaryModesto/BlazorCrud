using BlazorCrud.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base (options)
        {
            
        }
        public DbSet<Libro>? Libro {  get; set; }
    }
}
