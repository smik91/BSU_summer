using Lab.Models;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Bitmap bm;
        public Graphics g;
        public bool paint = false;
        public Point px, py;
        public Pen p = new Pen(Color.Black, 3);
        public int index;
        public int x, y, sx, sy, cx, cy;
        public List<Shape> Shapes = new List<Shape>();
        public List<Connector> Connectors = new List<Connector>();
        public Shape selectedShape = null;
        public Shape startConnectorShape = null;
        public int startx { get; set; }
        public int starty { get; set; }
        public int endx { get; set; }
        public int endy { get; set; }


        public class CanvasData
        {
            public List<Shape> Shapes { get; set; }
            public List<Connector> Connectors { get; set; }
            public Point px { get; set;}
            public Point py { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int sx { get; set; }
            public int sy { get; set; }
            public int cx { get; set; }
            public int cy { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(Pic.Width, Pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            Pic.Image = bm;
        }
        public void WorkAfterLoading()
        {
            bm = new Bitmap(Pic.Width, Pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            Pic.Image = bm;
        }

        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cx = e.X;
            cy = e.Y;

            if (index == 7)
            {
                startx = e.Location.X;
                starty = e.Location.Y;
                startConnectorShape = GetShapeAtPoint(e.Location);
            }
            if (index == 8)
            {
                selectedShape = GetShapeAtPoint(e.Location);
            }
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 8 && selectedShape != null)
                {
                    selectedShape.X += e.X - cx;
                    selectedShape.Y += e.Y - cy;
                    cx = e.X;
                    cy = e.Y;
                    RefreshCanvas();
                }
                if (index == 7 && startConnectorShape != null)
                {
                    RefreshCanvas();
                    using (var connectorPen = new Pen(Color.Black, 2))
                    {
                        var startCenter = startConnectorShape.GetCenter();
                        g.DrawLine(connectorPen, startCenter, e.Location);
                    }
                }
                Pic.Refresh();
            }

            x = e.X;
            y = e.Y;
            sx = e.X - cx;
            sy = e.Y - cy;
        }

        private void Pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            sx = x - cx;
            sy = y - cy;

            if (index == 3)
            {
                EllipseShape ellipse = new EllipseShape { X = cx, Y = cy, Width = sx, Height = sy };
                Shapes.Add(ellipse);
            }
            if (index == 4)
            {
                RectangleShape rect = new RectangleShape { X = cx, Y = cy, Width = sx, Height = sy };
                Shapes.Add(rect);
            }
            if (index == 5)
            {
                TriangleShape triangle = new TriangleShape { X = cx, Y = cy, Width = sx, Height = sy };
                Shapes.Add(triangle);
            }
            if (index == 7)
            {
                endx = e.Location.X;
                endy = e.Location.Y;
                Shape endShape = GetShapeAtPoint(new Point (endx, endy));
                if (startConnectorShape != null && endShape != null && startConnectorShape != endShape)
                {
                    Connectors.Add(new Connector { Start = startConnectorShape, End = endShape, startx = startx, starty = starty, endx = endx, endy = endy }) ;
                }
                startConnectorShape = null;
            }
            RefreshCanvas();
        }

        private Shape GetShapeAtPoint(Point point)
        {
            foreach (var shape in Shapes)
            {
                if (shape.Contains(point))
                {
                    return shape;
                }
            }
            return null;
        }

        private void RefreshCanvas()
        {
            g.Clear(Color.White);
            foreach (var shape in Shapes)
            {
                shape.Draw(g, p);
            }
            foreach (var connector in Connectors)
            {
                connector.Draw(g);
            }
            Pic.Image = bm;
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void BtnConnector_Click(object sender, EventArgs e)
        {
            index = 7;
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            index = 8;
        }

        private void Pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cx, cy, sx, sy);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cx, cy, sx, sy);
                }
                if (index == 5)
                {
                    DrawTriangle(g, p, cx, cy, sx, sy);
                }
                if (index == 7 && startConnectorShape != null)
                {
                    using (var connectorPen = new Pen(Color.Black, 2))
                    {
                        var startCenter = startConnectorShape.GetCenter();
                        g.DrawLine(connectorPen, startCenter, new Point(cx, cy));
                    }
                }
            }
        }

        private void DrawTriangle(Graphics g, Pen pen, int x, int y, int width, int height)
        {
            Point[] points = new Point[3];
            points[0] = new Point(x + width / 2, y);
            points[1] = new Point(x, y + height);
            points[2] = new Point(x + width, y + height);
            g.DrawPolygon(pen, points);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Shapes.Clear();
            Connectors.Clear();
            Pic.Image = bm;
            index = 0;
        }

        private void SaveCanvas(string filename)
        {
            var data = new CanvasData
            {
                Shapes = Shapes,
                Connectors = Connectors,
                px = px,
                py = py,
                x = x,
                y = y,
                sx = sx,
                sy = sy,
                cx = cx,
                cy = cy,

            };
            string jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(filename, jsonString);
        }

        private void LoadCanvas(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            var data = JsonConvert.DeserializeObject<CanvasData>(jsonString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            Shapes = data.Shapes;
            Connectors = data.Connectors;
            index = 0;
            px  = data.px;
            py = data.py;
            x = data.x;
            y = data.y; 
            sx = data.sx;
            sy = data.sy;
            cx = data.cx;
            cy = data.cy;
            WorkAfterLoading();
            RefreshCanvas();
        }

        

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "(*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveCanvas(sfd.FileName);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "(*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadCanvas(ofd.FileName);
            }
        }
    }
}
