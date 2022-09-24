using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Helpers;
using MyStore.Repositories;
using MyStore.Services.Utils;

namespace MyStore.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepo order;

        public OrderAppService(IOrderRepo order)
        {
            this.order = order;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await order.GetAllAsync();

            return orders.Select(x => x.ToDto()).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new AppExceptionHandler("You must enter product id");
            }

            var orderId = await order.GetByIdAsync(id);

            if (orderId == null)
            {
                throw new AppExceptionHandler("Order not found");
            }

            return orderId.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            var orderId = await order.GetByIdAsync(id);

            if (orderId == null)
            {
                throw new AppExceptionHandler("Order does not exist");
            }

            await order.DeleteAsync(orderId);
        }

        public async Task AddAsync(CreateOrderDto orders)
        {
            await order.AddAsync(orders.ToEntity());
        }

        public async Task UpdateAsync(OrderDto orders)
        {
            var exists = await order.GetByIdAsync(orders.Id);

            if (exists == null)
            {
                throw new AppExceptionHandler("Order does not exist");
            }
            await order.UpdateAsync(orders.ToEntity());
        }
    }
}
