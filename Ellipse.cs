using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1 {
    class Ellipse : GraphObject {
        int a;
        int b;
        public Ellipse():base() {
            a = 80;
            b = 60;
        }
        public override bool ContainsPoint(Point p) {
            return ((x - p.X) * (x - p.X) / (a * a) + (y - p.Y) * (y - p.Y) / (b * b)) <= 1;
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
