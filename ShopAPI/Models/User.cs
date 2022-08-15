namespace ShopAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FIO { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public int IdRole { get; set; }
        public Role? Role { get; set; }
    }
}