using RestaurantManagementApp.Models;
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
    public partial class UserMenuProductCheck : Form
    {
        public UserMenuProductCheck()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            UserControlPanelForm ctrlForm = new UserControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void lblBooking_Click(object sender, EventArgs e)
        {
            UserBooking BookingForm = new UserBooking();
            this.Hide();
            BookingForm.ShowDialog();
            this.Close();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void lblEdit_reset_Click(object sender, EventArgs e)
        {
            UserBills bill = new UserBills();
            this.Hide();
            bill.ShowDialog();
            this.Close();
        }

        private void lblLocation_Click(object sender, EventArgs e)
        {
            UserLocationBranchCheck location = new UserLocationBranchCheck();
            this.Hide();
            location.ShowDialog();
            this.Close();
        }

        private void btnBurger_Click(object sender, EventArgs e)
        {
            Session.product_name = "Burger";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnCoca_Click(object sender, EventArgs e)
        {
            Session.product_name = "Coca";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnFrenchFried_Click(object sender, EventArgs e)
        {
            Session.product_name = "French Fried";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnFriedRice_Click(object sender, EventArgs e)
        {
            Session.product_name = "Fried Rice";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnPocari_Click(object sender, EventArgs e)
        {
            Session.product_name = "Pocari";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnRevive_Click(object sender, EventArgs e)
        {
            Session.product_name = "Revive";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSausagePizza_Click(object sender, EventArgs e)
        {
            Session.product_name = "Sausage Pizza";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSteak_Click(object sender, EventArgs e)
        {
            Session.product_name = "Steak";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnJuice_Click(object sender, EventArgs e)
        {
            Session.product_name = "Juice";
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnAquafina_Click(object sender, EventArgs e)
        {
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSandWich_Click(object sender, EventArgs e)
        {
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnHotDog_Click(object sender, EventArgs e)
        {
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }
    }
}
