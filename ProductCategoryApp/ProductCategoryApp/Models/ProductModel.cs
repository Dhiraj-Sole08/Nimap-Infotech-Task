using ProductCategoryApp.Entities;

namespace ProductCategoryApp.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CategoryModel Category { get; set; } // Navigation property
    }
}
