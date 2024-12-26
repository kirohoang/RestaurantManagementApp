using RestaurantManagementApp;
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            branch1SeatsFloor2 brnch1floor2 = new branch1SeatsFloor2();
            this.Hide();
            brnch1floor2.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable1_Click(object sender, EventArgs e)
        {
            Session.seatID = "3";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable2_Click(object sender, EventArgs e)
        {
            Session.seatID = "4";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable3_Click(object sender, EventArgs e)
        {
            Session.seatID = "5";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void paneTable4_Click(object sender, EventArgs e)
        {
            Session.seatID = "6";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable5_Click(object sender, EventArgs e)
        {
            Session.seatID = "7";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable6_Click(object sender, EventArgs e)
        {
            Session.seatID = "8";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }

        private void panelTable7_Click(object sender, EventArgs e)
        {
            Session.seatID = "9";
            UserBooking userBooking = new UserBooking();
            this.Hide();
            userBooking.ShowDialog();
            this.Close();
        }
    }
}
