namespace MyStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Manufacturers Manufacturers { get; set; }
        public Category Category { get; set; }
    }
}
