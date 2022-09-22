using System.Collections.Generic;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Services
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetAllAsync(string product, string manufacturer, string category);
        Task<ProductDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(CreateProductDto product);
        Task UpdateAsync(ProductDto product);
        Task<List<ProductDto>> GetByIdsAsync(List<int> productIds);
        List<string> GetManifactureres();
        List<string> GetCategory();
    }
}
