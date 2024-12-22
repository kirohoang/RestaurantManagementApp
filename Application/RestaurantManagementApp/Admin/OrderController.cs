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
    public partial class OrderController : Form
    {
        public OrderController()
        {
            InitializeComponent();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController ctrlForm = new AdminController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }
    }
}
