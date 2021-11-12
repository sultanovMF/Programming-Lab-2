using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1 {
    internal class RandomObjectFactory : IGraphFactory {
        string current_type;
        static Random rand = new Random();
        public GraphObject CreateGraphObject() {

            if (rand.NextInt64(0, 2) == 0) {
                current_type = "Rectangle";
                return new Rectangle();
            } else {
                current_type = "Ellipse";
                return new Ellipse();
            }
        }
    }
}
