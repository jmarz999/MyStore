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

        public async Task<List<Product>> GetAllAsync(string product, string manufacturer, string category)
        {
            return await context.Products.AsNoTracking().ToListAsync();
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
    }
}