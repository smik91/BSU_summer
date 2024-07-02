namespace FloweShop.App.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sort { get; set; }
        public decimal PricePerFlower { get; set; }

        public IEnumerable<CompositionFlower> CompositionFlowers { get; set; }
    }
}
