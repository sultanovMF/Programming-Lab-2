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
        private List<GraphObject> elements = new List<GraphObject>();
        public MainForm() {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {

        }

        private void Exit(object sender, EventArgs e) {
            this.Close();
        }


        private void AddObject(object sender, EventArgs e) {
            elements.Add(new GraphObject());
            this.MainPanel.Invalidate();
        }

        private void PaintPanel(object sender, PaintEventArgs e) {
            foreach (GraphObject elem in elements) {
                elem.Draw(e.Graphics);
            }
        }

        private void CreateObjectWithMouse(object sender, MouseEventArgs e) {
     
            GraphObject go = new GraphObject();
            try {
                go.X = e.X;
                go.Y = e.Y;
            } catch (ArgumentException ex) { MessageBox.Show("Incorrect coord"); }

            this.MainPanel.Invalidate();
        }
    }
}
