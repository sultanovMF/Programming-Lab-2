using System;
using System.Drawing;

namespace WinFormsApp1 {
    abstract class GraphObject {
        static Random r = new Random();
        protected int x;
        public bool Selected { get; set; }
        public int X {
            get { return x; }
            set {
                x = value;
            }
        }

        public int Y {
            get { return y; }
            set {
                y = value;
            }
        }
        protected int y;
       
        protected SolidBrush brush;
        public GraphObject() {
            Selected = false;
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan };
            var c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            brush = new SolidBrush(c);
        }
        abstract public bool ContainsPoint(Point p);
        abstract public void Draw(Graphics g);
    }
}
