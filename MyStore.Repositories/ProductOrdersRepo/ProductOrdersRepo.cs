using System.Threading.Tasks;
using MyStore.Models;
using MyStore.Models.EntityFramework;

namespace MyStore.Repositories
{
    public class ProductOrdersRepo : IProductOrdersRepo
    {
        private readonly AppDbContext context;

        public ProductOrdersRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(ProductOrders productOrders)
        {
            await context.ProductOrders.AddAsync(productOrders);
            await context.SaveChangesAsync();
        }
    }
}
