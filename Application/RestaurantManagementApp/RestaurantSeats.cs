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
    public partial class RestaurantSeats : Form
    {
        public RestaurantSeats()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }
    }
}
