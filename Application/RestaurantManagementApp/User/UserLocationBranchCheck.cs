using Branch1;
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
    public partial class UserLocationBranchCheck : Form
    {
        public UserLocationBranchCheck()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
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
            UserMenuProductCheck MenuForm = new UserMenuProductCheck();
            this.Hide();
            MenuForm.ShowDialog();
            this.Close();
        }

        private void lblBooking_Click(object sender, EventArgs e)
        {

            UserBooking BookingForm = new UserBooking();
            this.Hide();
            BookingForm.ShowDialog();
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

        }

        private void panelCHAT1_Click(object sender, EventArgs e)
        {
            Session.brandID = "1"; 
            Branch1SeatsFloor1 branch1SeatsFloor1 = new Branch1SeatsFloor1();
            this.Hide();
            branch1SeatsFloor1.ShowDialog();
            this.Close();
        }

        private void panelCHAT2_Click(object sender, EventArgs e)
        {
            Session.brandID = "2";
            Branch1SeatsFloor1 branch1SeatsFloor1 = new Branch1SeatsFloor1();
            this.Hide();
            branch1SeatsFloor1.ShowDialog();
            this.Close();
        }
    }
}
