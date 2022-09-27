using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Repositories;
using MyStore.Services.Utils;

namespace MyStore.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IProductOrdersRepo productOrdersRepo;
        private readonly IProductRepo productRepo;

        public OrderAppService(IOrderRepo orderRepo, IProductOrdersRepo productOrdersRepo, IProductRepo productRepo)
        {
            this.orderRepo = orderRepo;
            this.productOrdersRepo = productOrdersRepo;
            this.productRepo = productRepo;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await orderRepo.GetAllAsync();

            return orders.Select(x => x.ToDto()).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new AppExceptionHandler("Product Id is invalid");
            }

            var order = await orderRepo.GetByIdAsync(id);

            if (order == null)
            {
                throw new AppExceptionHandler("Order is not found");
            }

            return order.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await orderRepo.GetByIdAsync(id);

            if (order == null)
            {
                throw new AppExceptionHandler("Order does not exist");
            }

            await orderRepo.DeleteAsync(order);
        }

        public async Task AddAsync(CreateOrderDto order)
        {
            var orderId = await orderRepo.AddAsync(order.ToEntity());

            foreach (var productId in order.ProductIds)
            {
                var product = await productRepo.GetByIdAsync(productId);

                if (product != null)
                {
                    var productOrder = new ProductOrders
                    {
                        OrderId = orderId,
                        ProductId = productId
                    };

                    await productOrdersRepo.AddAsync(productOrder);
                }
            }
        }

        public async Task UpdateAsync(OrderDto order)
        {
            var exists = await orderRepo.GetByIdAsync(order.Id);

            if (exists == null)
            {
                throw new AppExceptionHandler("Order does not exist");
            }

            await orderRepo.UpdateAsync(order.ToEntity());
        }
    }
}