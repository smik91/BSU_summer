namespace Lab.Models
{
    public class Connector
    {
        public Shape Start { get; set; }
        public Shape End { get; set; }
        public int? startx { get; set; }
        public int? starty { get; set; }
        public int? endx { get; set; }
        public int? endy { get; set; }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 4);
            if (Start != null && End != null || startx != null && starty != null && endx != null && endy != null)
            {
                Point startCenter = Start.GetCenter();
                Point endCenter = End.GetCenter();
                g.DrawLine(pen, startCenter, endCenter);
            }
        }
    }
}
