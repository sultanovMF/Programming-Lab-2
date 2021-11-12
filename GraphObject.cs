using System.Drawing;

namespace WinFormsApp1 {
    class GraphObject {
        static System.Random r = new System.Random();
        int x {
            get { return x; }
            set {
                if (value < 0) { throw new System.ArgumentException("x<0!"); }
                x = value;
            }
        }
        int y {
            get { return y; }
            set {
                if (value < 0) { throw new System.ArgumentException("x<0!"); }
                y = value;
            }
        }
        int h;
        int w;
        SolidBrush brush;
        public GraphObject() {
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Tomato,Color.Cyan };
            var c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            w = 50;
            h = 50;
            brush = new SolidBrush(c);
        }
        public void Draw(Graphics g) {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
