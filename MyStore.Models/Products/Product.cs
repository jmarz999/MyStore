using System.Collections.Generic;

namespace MyStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Img { get; set; }
        public double Price { get; set; }
        public Manufacturers Manufacturers { get; set; }
        public Category Category { get; set; }

        public List<ProductOrders> ProductOrders { get; set; }
    }
}
