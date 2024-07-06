namespace Lab.Models
{
    public class EllipseShape : Shape
    {
        public override void Draw(Graphics g, Pen p)
        {
            g.DrawEllipse(p, X, Y, Width, Height);
        }

        public override bool Contains(Point point)
        {
            return new Rectangle(X, Y, Width, Height).Contains(point);
        }

        public override Point GetCenter()
        {
            return new Point(X + Width / 2, Y + Height / 2);
        }
    }
}
