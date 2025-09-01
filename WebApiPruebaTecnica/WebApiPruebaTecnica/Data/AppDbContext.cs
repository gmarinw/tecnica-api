using Microsoft.EntityFrameworkCore;
using WebApiPruebaTecnica.Models;

namespace WebApiPruebaTecnica.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
