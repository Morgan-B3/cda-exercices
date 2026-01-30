using BlazorDemo.Shared.Models;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "api/produits";

        public ProductService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<Product?> AddAsync(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<Product>>(BaseUrl);
                return result ?? new List<Product>();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public Task<List<Product>> GetByCategoryAsync(string categorie)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SearchAsync(string terme)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(int id, ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
