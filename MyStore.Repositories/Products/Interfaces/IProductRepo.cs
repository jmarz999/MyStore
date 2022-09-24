using System.Collections.Generic;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repositories
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAllAsync(string product, Manufacturers manufacturer, Category category);
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(Product product);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<List<Product>> GetByIdsAsync(List<int> productIds);
    }
}