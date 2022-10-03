using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<ProductOrders> ProductOrders { get; set; }
    }
}