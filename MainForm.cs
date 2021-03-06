using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1 {
    
    public partial class MainForm : Form {
        string current_type;
        IGraphFactory factory = new RandomObjectFactory();
        int id = -1;
        private List<GraphObject> elements = new List<GraphObject>();
        public MainForm() {
            Random rand = new Random();
           
            if (rand.NextInt64(0, 3) == 0) {
                current_type = "Rectangle";
            } else if (rand.NextInt64(0, 2) == 1) {
                current_type = "Ellipse";
            } else {
                current_type = "ComposedRectangles";
            }
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {

        }

        private void Exit(object sender, EventArgs e) {
            this.Close();
        }

        private void Draw(GraphObject go) {
            elements.Add(go);
            this.MainPanel.Invalidate();
        }
        private void AddObject(object sender, EventArgs e) {
            if (current_type == "Rectangle") {
                Rectangle go = new Rectangle();
                Draw(go);
            } else if (current_type == "Ellipse") {
                Ellipse go = new Ellipse();
                Draw(go);
            } else if (current_type == "ComposedRectangles") {
                CompositeRectangles go = new CompositeRectangles();
                Draw(go);
            }

        }

        private void PaintPanel(object sender, PaintEventArgs e) {
            foreach (GraphObject elem in elements) {
                elem.Draw(e.Graphics);
            }
        }

        private void CreateObjectWithMouse(object sender, MouseEventArgs e) {
            if (current_type == "Rectangle") {
                Rectangle go = new Rectangle();
                try {
                    go.X = e.X;
                    go.Y = e.Y;
                } catch (ArgumentException ex) { MessageBox.Show("Incorrect coord"); }
                elements.Add(go);
            } else if (current_type == "Ellipse") {
                Ellipse go = new Ellipse();
                try {
                    go.X = e.X;
                    go.Y = e.Y;
                } catch (ArgumentException ex) {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            } else if (current_type == "ComposedRectangles") {
                CompositeRectangles go = new CompositeRectangles();
                try {
                    go.X = e.X;
                    go.Y = e.Y;
                } catch (ArgumentException ex) {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            }
            this.MainPanel.Invalidate();
        }
        private void SelectObject(object sender, MouseEventArgs e) {
            if (elements.Count > 0) {
                int i = 0;
                foreach (GraphObject element in elements) {
                    if (element.ContainsPoint(e.Location)) {
                        id = i;
                    }
                    element.Selected = false;
                    i++;
                }
                if (id > -1) {
                    elements[id].Selected = true;
                    this.MainPanel.Invalidate();
                }
                
            }
        }

        private void FiguresMenuItems_Click(object sender, EventArgs e) {

        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e) {
            current_type = "Rectangle";
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e) {
            current_type = "Ellipse";
        }

        private void ClearBtn_Click(object sender, EventArgs e) {
            elements.Clear();
            this.MainPanel.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            if (id > -1) {
                elements[id].X -= 5;
                this.MainPanel.Invalidate();
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            if (id > -1) {
                elements[id].X += 5;
                this.MainPanel.Invalidate();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            if (id > -1) {
                elements[id].Y -= 5;
                this.MainPanel.Invalidate();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            if (id > -1) {
                elements[id].Y += 5;
                this.MainPanel.Invalidate();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            if (id > -1) {
                elements.Remove(elements[id]);
                id = -1;
                this.MainPanel.Invalidate();
            }
        }

        private void twoTypesToolStripMenuItem_Click(object sender, EventArgs e) {
            factory = new TwoTypeFactory();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e) {
            factory = new RandomObjectFactory();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '+') {
                Draw(factory.CreateGraphObject());
            }
        }

        private void composedRectangleToolStripMenuItem_Click(object sender, EventArgs e) {
            current_type = "ComposedRectangles";
        }

    }
}
