using System;
using System.Drawing;

namespace WinFormsApp1 {
    class GraphObject {
        static Random r = new Random();
        private int x;

        int X {
            get { return x; }
            set {
                x = value;
            }
        }

        int Y {
            get { return y; }
            set {
                y = value;
            }
        } 
        public int y;
        int h;
        int w;
        SolidBrush brush;
        public GraphObject() {
           
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan };
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
