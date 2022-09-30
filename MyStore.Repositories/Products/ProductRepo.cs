using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Models.EntityFramework;

namespace MyStore.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext context;

        public ProductRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAllAsync(string product, Manufacturers manufacturer, Category category)
        {
            return await context.Products
                .WhereIf(!string.IsNullOrWhiteSpace(product), x => x.Name.ToLower().Contains(product.ToLower()))
                .WhereIf(manufacturer != Manufacturers.None, x => x.Manufacturers.Equals(manufacturer))
                .WhereIf(category != Category.None, x => x.Category.Equals(category))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task DeleteAsync(Product product)
        {
            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }

        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);

            await context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetByIdsAsync(List<int> productIds)
        {
            return await context.Products.AsNoTracking().Where(x => productIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<bool> CheckExistingProducts(string product, Manufacturers manufacturer, Category category)
        {
            return await context.Products.AnyAsync(x => x.Name.Equals(product) && x.Category.Equals(category) && x.Manufacturers.Equals(manufacturer));
        }
    }
}