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
                Img = dto.Img,
                ExpirationDate = dto.ExpirationDate,
                IsVegan = dto.IsVegan,
                Quantity = dto.Quantity
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
                Img = product.Img,
                ExpirationDate = product.ExpirationDate,
                IsVegan = product.IsVegan,
                Quantity = product.Quantity,
                Ingredients = product.ProductIngredients.Select(x => x.ToDto()).ToList()
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
                Img = product.Img,
                ExpirationDate = product.ExpirationDate,
                IsVegan = product.IsVegan,
                Quantity = product.Quantity
            };
        }

        public static Order ToEntity(this OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                Price = dto.Price,
                Address = dto.Address,
                Email = dto.Email,
                LastName = dto.LastName,
                Name = dto.Name,
                Status = dto.Status.ToEnum(OrderStatus.Pending)
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

        public static UserDto EntityToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
                Gender = user.Gender.GetDisplayName(),
                DateOfBirth = user.DateOfBirth
            };
        }

        public static User DtoToEntity(this CreateUserDto user)
        {
            return new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender.ToEnum(Gender.Other),
                PasswordHash = user.Password,
                UserName = user.Username
            };
        }

        public static User DtoToEntity(this UserDto user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender.ToEnum(Gender.Other),
                UserName = user.Username
            };
        }

        public static Ingredients ToEntity(this IngredientsDto ingredient)
        {
            return new Ingredients
            {
                Name = ingredient.Name,
                ProductId = ingredient.ProductId
            };
        }

        public static IngredientsDto ToDto(this Ingredients ingredient)
        {
            return new IngredientsDto
            {
                Name = ingredient.Name,
                ProductId = ingredient.ProductId
            };
        }
    }
}