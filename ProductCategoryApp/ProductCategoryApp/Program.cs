using Microsoft.EntityFrameworkCore;
using ProductCategoryApp.Contracts;
using ProductCategoryApp.DBContext;
using ProductCategoryApp.DerivedClasses;
using ProductCategoryApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProduct, ProductCategoryApp.DerivedClasses.Product>();

builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer("Data Source=DHIRAJ\\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=True;Trust Server Certificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services=scope.ServiceProvider;
    try
    {
        var productDBContext = services.GetRequiredService<ProductContext>();
        var dbContext = services.GetRequiredService<ProductContext>();

        SeedProductData(productDBContext);
    }
    catch(Exception ex)
    {

    }
}

void SeedProductData(ProductContext productDBContext)
{
    if (!productDBContext.Categories.Any())
    {
        //HardCoded Values
        var categories = new List<Category>
        {
            new Category { Name = "Electronics" },
            new Category { Name = "Clothing" },
            new Category { Name = "Home Appliances" },
            new Category { Name = "Books" },
            new Category { Name = "Toys" },
            new Category { Name = "Sports" },
            new Category { Name = "Groceries" },
            new Category { Name = "Furniture" },
            new Category { Name = "Beauty & Personal Care" },
            new Category { Name = "Stationery" }
        };

        productDBContext.Categories.AddRange(categories);
        productDBContext.SaveChanges();
    }
    if (!productDBContext.Products.Any())
    {
        // Fetch all categories
        var categories = productDBContext.Categories.ToList(); 
        var products = new List<ProductCategoryApp.Entities.Product>
        {
            // Electronics
            new ProductCategoryApp.Entities.Product  { Name = "Smartphone", Price = 699.99M, CategoryId = categories.First(c => c.Name == "Electronics").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Laptop", Price = 999.99M, CategoryId = categories.First(c => c.Name == "Electronics").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Headphones", Price = 49.99M, CategoryId = categories.First(c => c.Name == "Electronics").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Tablet", Price = 399.99M, CategoryId = categories.First(c => c.Name == "Electronics").CategoryId },

            // Clothing
            new ProductCategoryApp.Entities.Product { Name = "T-Shirt", Price = 19.99M, CategoryId = categories.First(c => c.Name == "Clothing").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Jeans", Price = 49.99M, CategoryId = categories.First(c => c.Name == "Clothing").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Jacket", Price = 89.99M, CategoryId = categories.First(c => c.Name == "Clothing").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Shoes", Price = 79.99M, CategoryId = categories.First(c => c.Name == "Clothing").CategoryId },

            // Home Appliances
            new ProductCategoryApp.Entities.Product { Name = "Vacuum Cleaner", Price = 129.99M, CategoryId = categories.First(c => c.Name == "Home Appliances").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Air Conditioner", Price = 499.99M, CategoryId = categories.First(c => c.Name == "Home Appliances").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Microwave", Price = 99.99M, CategoryId = categories.First(c => c.Name == "Home Appliances").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Refrigerator", Price = 599.99M, CategoryId = categories.First(c => c.Name == "Home Appliances").CategoryId },

            // Books
            new ProductCategoryApp.Entities.Product { Name = "The Great Gatsby", Price = 14.99M, CategoryId = categories.First(c => c.Name == "Books").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "To Kill a Mockingbird", Price = 12.99M, CategoryId = categories.First(c => c.Name == "Books").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "1984", Price = 15.99M, CategoryId = categories.First(c => c.Name == "Books").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Moby Dick", Price = 9.99M, CategoryId = categories.First(c => c.Name == "Books").CategoryId },

            // Toys
            new ProductCategoryApp.Entities.Product { Name = "Lego Set", Price = 59.99M, CategoryId = categories.First(c => c.Name == "Toys").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Action Figure", Price = 19.99M, CategoryId = categories.First(c => c.Name == "Toys").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Board Game", Price = 29.99M, CategoryId = categories.First(c => c.Name == "Toys").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "RC Car", Price = 49.99M, CategoryId = categories.First(c => c.Name == "Toys").CategoryId },

            // Sports
            new ProductCategoryApp.Entities.Product { Name = "Football", Price = 19.99M, CategoryId = categories.First(c => c.Name == "Sports").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Cricket Bat", Price = 39.99M, CategoryId = categories.First(c => c.Name == "Sports").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Tennis Racket", Price = 89.99M, CategoryId = categories.First(c => c.Name == "Sports").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Basketball", Price = 24.99M, CategoryId = categories.First(c => c.Name == "Sports").CategoryId },

            // Groceries
            new ProductCategoryApp.Entities.Product { Name = "Rice", Price = 2.99M, CategoryId = categories.First(c => c.Name == "Groceries").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Pasta", Price = 1.99M, CategoryId = categories.First(c => c.Name == "Groceries").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Cooking Oil", Price = 6.99M, CategoryId = categories.First(c => c.Name == "Groceries").CategoryId },
            new ProductCategoryApp.Entities.Product { Name = "Sugar", Price = 1.49M, CategoryId = categories.First(c => c.Name == "Groceries").CategoryId }
        };

        productDBContext.Products.AddRange(products);
        productDBContext.SaveChanges();
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
