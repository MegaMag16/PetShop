namespace ShopAPI.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public float Amount { get; set; }
        public User? User { get; set; }
        public List<BuyForShop>? BuyForShops { get; set; }
    }
}
