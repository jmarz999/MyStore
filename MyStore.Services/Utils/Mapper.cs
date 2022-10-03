using System.Collections.Generic;
using System.Linq;
using MyStore.Models;

namespace MyStore.Services.Utils
{
    public static class Mapper
    {
        public static Product ToEntity(this CreateProductDto dto)
        {
            return new Product
            {
                Category = dto.Category.ToEnum(Category.None),
                Description = dto.Description,
                Manufacturers = dto.Manufacturers.ToEnum(Manufacturers.None),
                Name = dto.Name,
                Price = dto.Price,
                Img = dto.Img
            };
        }
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Category = product.Category.GetDisplayName(),
                Description = product.Description,
                Manufacturers = product.Manufacturers.GetDisplayName(),
                Name = product.Name,
                Price = product.Price, 
                Img = product.Img
            };
        }
        public static Product ToEntity(this ProductDto product)
        {
            return new Product
            {
                Id = product.Id,
                Category = product.Category.ToEnum(Category.None),
                Description = product.Description,
                Manufacturers = product.Manufacturers.ToEnum(Manufacturers.None),
                Name = product.Name,
                Price = product.Price,
                Img = product.Img
            };
        }

        public static Order ToEntity(this OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                Price = dto.Price
            };
        }

        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Price = order.Price,
                Address = order.Address,
                Email = order.Email,
                LastName = order.LastName,
                Name = order.Name,
                Status = order.Status.GetDisplayName(),
                Products = order.ProductOrders?.Select(x => x.Product.ToDto()).ToList()
            };
        }

        public static Order ToEntity(this CreateOrderDto dto)
        {
            return new Order
            {
                Price = (decimal)dto.Price,
                Address = dto.Address,
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                Status = OrderStatus.Pending
            };
        }
    }
}
