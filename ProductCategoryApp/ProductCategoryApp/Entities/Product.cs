﻿namespace ProductCategoryApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Category Category { get; set; } // Navigation property
    }
}
