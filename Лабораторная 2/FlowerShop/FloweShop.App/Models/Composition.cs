namespace FloweShop.App.Models
{
    public class Composition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<CompositionFlower> CompositionFlowers { get; set; } = new List<CompositionFlower>();
    }
}
