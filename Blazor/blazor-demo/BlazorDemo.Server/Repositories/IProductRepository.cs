using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchAsync(string terme);
        Task<IEnumerable<Product>> GetByCategoryAsync(string categorie);
        Task<IEnumerable<string>> GetCategoriesAsync();
        Task<decimal> GetStockValueAsync();

    }
}
