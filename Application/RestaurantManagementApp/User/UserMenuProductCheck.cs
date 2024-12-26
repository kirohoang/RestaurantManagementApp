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
            Session.product_id = "8";
            Session.product_name = "Burger";
            Session.price = 35000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnCoca_Click(object sender, EventArgs e)
        {
            Session.product_id = "9";
            Session.product_name = "Coca";
            Session.price = 10000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnFrenchFried_Click(object sender, EventArgs e)
        {
            Session.product_id = "10";
            Session.product_name = "French Fried";
            Session.price = 20000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnFriedRice_Click(object sender, EventArgs e)
        {
            Session.product_id = "11";
            Session.product_name = "Fried Rice";
            Session.price = 25000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnPocari_Click(object sender, EventArgs e)
        {
            Session.product_id = "12";
            Session.product_name = "Pocari";
            Session.price = 14000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnRevive_Click(object sender, EventArgs e)
        {
            Session.product_id = "13";
            Session.product_name = "Revive";
            Session.price = 10000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSausagePizza_Click(object sender, EventArgs e)
        {
            Session.product_id = "14";
            Session.product_name = "Sausage Pizza";
            Session.price = 30000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSteak_Click(object sender, EventArgs e)
        {
            Session.product_id = "15";
            Session.product_name = "Steak";
            Session.price = 45000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnJuice_Click(object sender, EventArgs e)
        {
            Session.product_name = "Juice";
            Session.price = 14000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnAquafina_Click(object sender, EventArgs e)
        {
            Session.product_id = "Aquafina";
            Session.price = 5000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnSandWich_Click(object sender, EventArgs e)
        {
            Session.product_name = "Sandwich";
            Session.price = 20000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }

        private void btnHotDog_Click(object sender, EventArgs e)
        {
            Session.product_name = "Hot Dog";
            Session.price = 25000;
            UserBooking booking = new UserBooking();
            this.Hide();
            booking.ShowDialog();
            this.Close();
        }
    }
}
