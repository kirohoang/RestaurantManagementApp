using RestaurantManagementApp.Admin;
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
    public partial class AdminController : Form
    {
        public AdminController()
        {
            InitializeComponent();
        }
        private void PicCustomer_Click(object sender, EventArgs e)
        {
            CustomerController ctrlForm = new CustomerController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicProduct_Click(object sender, EventArgs e)
        {
            ProductController ctrlForm = new ProductController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicLocation_Click(object sender, EventArgs e)
        {
            BranchController ctrlForm = new BranchController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicOrder_Click(object sender, EventArgs e)
        {
            OrderController ctrlForm = new OrderController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PicSeat_Click(object sender, EventArgs e)
        {
            SeatController ctrForm = new SeatController();
            this.Hide();
            ctrForm.ShowDialog();
            this.Close();
        }

        private void PicTransaction_Click(object sender, EventArgs e)
        {
            TransactionController ctrlForm = new TransactionController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void PicOrderDetails_Click(object sender, EventArgs e)
        {
            OrderDetailsController ctrForm = new OrderDetailsController();
            this.Hide();
            ctrForm.ShowDialog();
            this.Close();
        }

        private void PicCustomerDetails_Click(object sender, EventArgs e)
        {
            CustomerDetailsController ctrForm = new CustomerDetailsController();
            this.Hide();
            ctrForm.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SignIn signInForm = new SignIn();
            this.Hide();
            signInForm.ShowDialog();
            this.Close();
        }
    }
}
