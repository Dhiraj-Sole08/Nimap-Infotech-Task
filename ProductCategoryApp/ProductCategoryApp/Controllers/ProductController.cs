using Microsoft.AspNetCore.Mvc;
using ProductCategoryApp.Contracts;
using ProductCategoryApp.Models;

namespace ProductCategoryApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct prods;

        public ProductController(IProduct products)
        {
            this.prods = products;
        }

        public async Task< IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var products=await prods.getProducts();

            var totalRecords = products.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedProducts = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var viewModel = new ProductListViewModel
            {
                Products = paginatedProducts,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View("Product",viewModel);
        }
    }
}
