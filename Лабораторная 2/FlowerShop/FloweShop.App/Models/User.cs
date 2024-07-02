namespace FloweShop.App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
