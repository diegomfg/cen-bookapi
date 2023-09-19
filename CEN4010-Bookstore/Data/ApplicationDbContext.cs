using CEN4010_Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace CEN4010_Bookstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
