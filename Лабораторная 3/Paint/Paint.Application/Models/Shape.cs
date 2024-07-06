namespace Lab.Models
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract void Draw(Graphics g, Pen p);
        public abstract bool Contains(Point point);

        public virtual Point GetCenter()
        {
            return new Point(X, Y);
        }
    }
}
