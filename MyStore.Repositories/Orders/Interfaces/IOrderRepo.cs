using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repositories
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(Order order);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
