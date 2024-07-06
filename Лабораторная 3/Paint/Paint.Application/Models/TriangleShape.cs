namespace Lab.Models
{
    public class TriangleShape : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override void Draw(Graphics g, Pen p)
        {
            Point[] points = new Point[3];
            points[0] = new Point(X + Width / 2, Y);
            points[1] = new Point(X, Y + Height);
            points[2] = new Point(X + Width, Y + Height);
            g.DrawPolygon(p, points);
        }

        public override bool Contains(Point point)
        {
            Point[] points = new Point[3];
            points[0] = new Point(X + Width / 2, Y);
            points[1] = new Point(X, Y + Height);
            points[2] = new Point(X + Width, Y + Height);
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddPolygon(points);
            return path.IsVisible(point);
        }

        private bool IsPointInPolygon(Point[] polygon, Point point)
        {
            int polygonLength = polygon.Length, i = 0;
            bool inside = false;
            float pointX = point.X, pointY = point.Y;
            float startX, startY, endX, endY;
            Point endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX; startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X; endY = endPoint.Y;
                inside ^= (endY > pointY ^ startY > pointY) && ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }

        public override Point GetCenter()
        {
            int centerX = X + Width / 2;
            int centerY = Y + Height / 2;
            return new Point(centerX, centerY);
        }
    }
}
