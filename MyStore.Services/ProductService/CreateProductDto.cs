using System;
using System.Collections.Generic;

namespace MyStore.Services
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Manufacturers { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public string Quantity { get; set; }
        public bool IsVegan { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<IngredientsDto> Ingredients { get; set; }
    }
}