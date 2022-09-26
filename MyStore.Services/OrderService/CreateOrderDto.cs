using System.Collections.Generic;

namespace MyStore.Services
{
    public class CreateOrderDto
    {
        public List<int> ProductIds { get; set; }
        public int Price { get; set; }
    }
}
