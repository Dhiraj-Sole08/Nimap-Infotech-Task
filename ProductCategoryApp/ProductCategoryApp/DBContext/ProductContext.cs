using Microsoft.EntityFrameworkCore;
using ProductCategoryApp.Entities;

namespace ProductCategoryApp.DBContext
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
