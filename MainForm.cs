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

        private List<GraphObject> elements = new List<GraphObject>();
        public MainForm() {
            Random rand = new Random();
           
            if (rand.NextInt64(0, 2) == 0) {
                current_type = "Rectangle";
            } else {
                current_type = "Ellipse";
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
            } else {
                Ellipse go = new Ellipse();
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
                Draw(go);
            } else {
                Ellipse go = new Ellipse();
                try {
                    go.X = e.X;
                    go.Y = e.Y;
                } catch (ArgumentException ex) {
                    MessageBox.Show("Incorrect coord");
                }
                Draw(go);
            }
        }
        private void SelectObject(object sender, MouseEventArgs e) {
            if (elements.Count > 0) {
                int id = -1;
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
    }
}
