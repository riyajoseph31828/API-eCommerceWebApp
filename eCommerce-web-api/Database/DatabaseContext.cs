using eCommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_web_api.Database
{
    public class DatabaseContext : DbContext
    {
        //constructor
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
