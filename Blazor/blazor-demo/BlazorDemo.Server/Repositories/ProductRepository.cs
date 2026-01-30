using BlazorDemo.Server.Data;
using BlazorDemo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Server.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _dbSet.Where(p => p.Category.ToLower() == category.ToLower()).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            return await _dbSet.Select(p => p.Category).Distinct().OrderBy(c => c).ToListAsync();
        }

        public async Task<decimal> GetStockValueAsync()
        {
            return await _dbSet.SumAsync(p => p.Price * p.Stock);
        }

        public async Task<IEnumerable<Product>> SearchAsync(string terme)
        {
            if (string.IsNullOrWhiteSpace(terme)) return await GetAllAsync();
            var t = terme.ToLower();
            return await _dbSet
                .Where(p => p.Name.ToLower().Contains(t) || (p.Description != null && p.Description.ToLower().Contains(t)))
                .OrderBy(p => p.Name).ToListAsync();
        }
    }
}
