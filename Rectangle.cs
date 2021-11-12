using System;
using System.Drawing;
namespace WinFormsApp1 {
    class Rectangle: GraphObject {
        protected int h;
        protected int w;
        public Rectangle() : base() {
            h = 50;
            w = 50;
        }
        public override bool ContainsPoint(Point p) {
            return (p.X <= x + w) & (p.X >= x) & (p.Y >= y) & (p.Y <= y + h);
        }
        public override void Draw(Graphics g) {
            g.FillRectangle(brush, x, y, w, h);

            if (Selected) {
                g.DrawRectangle(Pens.Cyan, x, y, w, h);
            } else {
                g.DrawRectangle(Pens.Black, x, y, w, h);
            }
        }
    }
}
