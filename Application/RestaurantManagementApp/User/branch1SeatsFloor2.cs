using RestaurantManagementApp;
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
    public partial class branch1SeatsFloor2 : Form
    {
        public branch1SeatsFloor2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelStair_MouseClick(object sender, MouseEventArgs e)
        {
            Branch1SeatsFloor1 brnch1floor1 = new Branch1SeatsFloor1();
            this.Hide();
            brnch1floor1.ShowDialog();
            this.Close();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Branch1SeatsFloor1 branch1SeatsFloor1 = new Branch1SeatsFloor1();
            this.Hide();
            branch1SeatsFloor1.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }
    }
}
