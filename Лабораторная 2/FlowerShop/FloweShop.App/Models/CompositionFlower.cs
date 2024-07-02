namespace FloweShop.App.Models
{
    public class CompositionFlower
    {
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }

        public int FlowerId { get; set; }
        public Flower Flower { get; set; }

        public int Quantity { get; set; }
    }
}
