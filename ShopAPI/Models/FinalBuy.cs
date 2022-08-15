namespace ShopAPI.Models
{
    public class FinalBuy
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public float Amount { get; set; }
        public string? UserPhone { get; set; }
        public string? Address { get; set; }
        public User? User { get; set; }
        public List<Buy>? UserBasket { get; set; }
    }
}
