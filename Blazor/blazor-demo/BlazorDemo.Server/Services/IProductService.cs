using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Services
{
    public interface IProductService
    {
        public interface IProductService
        {
            Task<List<Product>> GetAllAsync();
            Task<Product?> GetAllByIdAsync(int id);
            Task<List<Product>> SearchAsync(string terme);
            Task<List<Product>> GetByCategoryAsync(string categorie);
            Task<Product> AddAsync(ProductDto dto);
            Task<Product?> UpdateAsync(int id, ProductDto dto);
            Task<bool> DeleteAsync(int id);
            Task<List<string>> GetCategoriesAsync();

        }
    }
    }
