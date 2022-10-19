using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repositories
{
    public interface IIngredientsRepo
    {
        Task AddRange(List<Ingredients> ingredients);
    }
}
