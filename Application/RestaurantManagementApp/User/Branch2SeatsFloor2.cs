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
    public partial class Branch2SeatsFloor2 : Form
    {
        public Branch2SeatsFloor2()
        {
            InitializeComponent();
        }

        private void panelStair_Paint(object sender, PaintEventArgs e)
        {
            Branch2SeatsFloor1 brnch2Floor1 = new Branch2SeatsFloor1();
            this.Hide();
            brnch2Floor1.ShowDialog();
            this.Close();
        }
    }
}
