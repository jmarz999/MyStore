using System.Collections.Generic;
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

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

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
    }
}
