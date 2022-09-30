using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Repositories;
using MyStore.Services.Utils;

namespace MyStore.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepo product;

        public ProductAppService(IProductRepo product)
        {
            this.product = product;
        }

        public async Task<List<ProductDto>> GetAllAsync(string productName, string manufacturer, string category)
        {
            var products = await product.GetAllAsync(productName, manufacturer.ToEnum(Manufacturers.None), category.ToEnum(Category.None));

            return products.Select(x => x.ToDto()).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            // check if the id has a value and confirm that is not 0
            if (id == 0)
            {
                throw new AppExceptionHandler("You must enter product id");
            }

            var productId = await product.GetByIdAsync(id);

            if (productId == null)
            {
                throw new AppExceptionHandler("Product not found");
            }

            return productId.ToDto();
            //check if the product retrieved from the database is null -> if null show a message to the user.
        }

        public async Task DeleteAsync(int id)
        {
            // instead of sending an id in the repository try and find the product that we need to delete in the database
            var products = await product.GetByIdAsync(id);

            if (products == null)
            {
                throw new AppExceptionHandler("Produst does not exist");
            }

            await product.DeleteAsync(products);
        }

        public async Task AddAsync(CreateProductDto products)
        {
            var exists = await product.CheckExistingProducts(products.Name, products.Manufacturers.ToEnum(Manufacturers.None), products.Category.ToEnum(Category.None));
            
            if (exists)
            {
                throw new AppExceptionHandler("Product already exists.");
            }
            else
            {
                await product.AddAsync(products.ToEntity());
            }
        }

        public async Task UpdateAsync(ProductDto products)
        {
            //take the procduct by products.id from the database and confirm that it exists if it does update it
            var exists = await product.GetByIdAsync(products.Id);

            if (exists == null)
            {
                throw new AppExceptionHandler("Produst does not exist");
            }

            await product.UpdateAsync(products.ToEntity());
        }

        public async Task<List<ProductDto>> GetByIdsAsync(List<int> productIds)
        {
            if (!productIds.Any())
            {
                throw new AppExceptionHandler("List is empty");
            }

            var products = await product.GetByIdsAsync(productIds);

            return products.Select(x => x.ToDto()).ToList();
        }

        public List<string> GetManifactureres()
        {
            var manufacturers = EnumExtensions.GetValues<Manufacturers>();

            return manufacturers.Select(x => x.GetDisplayName()).ToList();
        }

        public List<string> GetCategory()
        {
            var catergories = EnumExtensions.GetValues<Category>();

            return catergories.Select(x => x.GetDisplayName()).ToList();
        }
    }
}