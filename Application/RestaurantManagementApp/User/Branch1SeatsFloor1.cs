using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Branch1
{
    public partial class Branch1SeatsFloor1 : Form
    {
        public Branch1SeatsFloor1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Stair_click(object sender, MouseEventArgs e)
        {
            branch1SeatsFloor2 brnch1floor2 = new branch1SeatsFloor2();
            this.Hide();
            brnch1floor2.ShowDialog();
            this.Close();
        }
    }
}
