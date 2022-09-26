using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Services
{
    public interface IOrderAppService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(CreateOrderDto order);
        Task UpdateAsync(OrderDto order);

    }
}