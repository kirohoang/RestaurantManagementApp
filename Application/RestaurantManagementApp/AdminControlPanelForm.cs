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
    public partial class AdminControlPanelForm : Form
    {
        public AdminControlPanelForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           AdminAddCustomer ctrlForm = new AdminAddCustomer();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicProduct_Click(object sender, EventArgs e)
        {
            AdminAddProduct ctrlForm = new AdminAddProduct();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicLocation_Click(object sender, EventArgs e)
        {
            AdminAddLocation ctrlForm = new AdminAddLocation();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicOrder_Click(object sender, EventArgs e)
        {
            AdminAddOrder ctrlForm = new AdminAddOrder();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }
    }
}
