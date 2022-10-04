using System.Collections.Generic;

namespace MyStore.Services
{
    public class CreateOrderDto
    {
        public List<int> ProductIds { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
