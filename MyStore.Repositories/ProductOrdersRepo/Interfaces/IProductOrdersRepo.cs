using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repositories
{
    public interface IProductOrdersRepo
    {
        Task AddAsync(ProductOrders productOrders);
    }
}
