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
    public partial class UserTransactions : Form
    {
        public UserTransactions()
        {
            InitializeComponent();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void UserTransactions_Load(object sender, EventArgs e)
        {
            txtID.Text = Session.Id;


        }
    }
}
