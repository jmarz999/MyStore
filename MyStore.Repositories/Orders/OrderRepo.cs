using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Models.EntityFramework;

namespace MyStore.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext context;

        public OrderRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders.AsNoTracking().FirstOrDefaultAsync(x => id == x.Id);
        }

        public async Task DeleteAsync(Order order)
        {
            context.Orders.Remove(order);

            await context.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Order order)
        {
            context.Orders.Add(order);

            await context.SaveChangesAsync();

            return order.Id;
        }

        public async Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);

            await context.SaveChangesAsync();
        }
    }
}