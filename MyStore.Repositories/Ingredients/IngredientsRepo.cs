using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Models.EntityFramework;

namespace MyStore.Repositories
{
    public class IngredientsRepo : IIngredientsRepo
    {
        private readonly AppDbContext appContext;

        public IngredientsRepo(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task AddRange(List<Ingredients> ingredients)
        {
            await appContext.AddRangeAsync(ingredients);

            await appContext.SaveChangesAsync();
        }
    }
}