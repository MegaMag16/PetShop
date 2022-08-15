namespace ShopAPI.Models
{
    public class BuyForShop
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public float Amount { get; set; }

        public Product? Product { get; set; }
    }
}
