using ProductCategoryApp.Entities;

namespace ProductCategoryApp.Contracts
{
    public interface IProduct
    {
        Task<List<Product>> getProducts();
    }
}
