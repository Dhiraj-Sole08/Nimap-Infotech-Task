using Microsoft.EntityFrameworkCore;
using ProductCategoryApp.Contracts;
using ProductCategoryApp.DBContext;

namespace ProductCategoryApp.DerivedClasses
{
    public class Product : IProduct
    {
        private readonly ProductContext _context;

        public Product(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Entities.Product>> getProducts()
        {
            return await _context.Products
            .Include(p => p.Category) // Include related Category data
            .ToListAsync();
        }


    }
}
