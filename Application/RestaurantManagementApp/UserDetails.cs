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
    public partial class UserDetails : Form
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserControlPanelForm ctrlForm = new UserControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            UserTransactions transactions = new UserTransactions();
            this.Hide();
            transactions.ShowDialog();
            this.Close();
        }
    }
}
