using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1 {
    internal class CompositeRectangles : GraphObject {
        List<Rectangle> Rects = new List<Rectangle>(9);
        public CompositeRectangles() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Rectangle rect = new Rectangle();
                    Rects.Add(rect);
                }
            }
        }
        public override bool ContainsPoint(Point p) {
            bool key = false;
            foreach(Rectangle r in Rects) {
                if (r.ContainsPoint(p)) {
                    key = true;
                }
            }
            return key;
        }

        public override void Draw(Graphics g) {

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {

                    Rects[j + 3*i].X = X + Rects[j + 3 * i].W * j + j * 10;
                    Rects[j + 3 * i].Y = Y + Rects[j + 3 * i].H * i + i * 10;
                    if (Selected) {
                        Rects[j + 3 * i].Selected = true;
                    } else {
                        Rects[j + 3 * i].Selected = false;
                    }
                    Rects[j + 3 * i].Draw(g);
                }
            }
        }
    }
}
