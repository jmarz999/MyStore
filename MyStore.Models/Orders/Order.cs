using System.Collections.Generic;

namespace MyStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public List<ProductOrders> ProductOrders { get; set; }
    }
}