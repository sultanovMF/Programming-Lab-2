using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1 {
    class Ellipse : GraphObject {
        float a;
        float b;
        public Ellipse():base() {
            a = 80;
            b = 60;
        }
        public override bool ContainsPoint(Point p) {
            float dx = a / 2.0f;
            float dy = b / 2.0f;
            return ((x + dx - p.X) * (x + dx - p.X)) / (dx * dx) + ((y + dy - p.Y) * (y + dy - p.Y)) / (dy * dy) <= 1;
        }

        public override void Draw(Graphics g) {
            g.FillEllipse(brush, x, y, a, b);

            if (Selected) {
                g.DrawEllipse(Pens.White, x, y, a, b);
            } else {
                g.DrawEllipse(Pens.Black, x, Y, a, b);
            }
        }
    }
}
