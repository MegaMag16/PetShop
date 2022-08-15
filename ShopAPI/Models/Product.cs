namespace ShopAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }

        public string? Description { get; set; }

        public int IdCategory { get; set; }

        public string? UrlImage { get; set; }

        public float Price { get; set; }

        public Category? Category { get; set; }
    }
}
