using System.Collections.Generic;
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
    }
}
