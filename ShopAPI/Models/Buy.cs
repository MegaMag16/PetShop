namespace ShopAPI.Models
{
    public class Buy
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public float Amount { get; set; }
        public bool IsFinished { get; set; }

        public Product? Product { get; set; }
        public User? User { get; set; }
    }
}
