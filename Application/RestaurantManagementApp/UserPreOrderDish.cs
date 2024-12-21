using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp
{
    public partial class UserPreOrderDish : Form
    {
        public UserPreOrderDish()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            UserBooking BookingForm = new UserBooking();
            this.Hide();
            BookingForm.ShowDialog();
            this.Close();
        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            UserBooking BookingForm = new UserBooking();
            this.Hide();
            BookingForm.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
