using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp.Admin
{
    public partial class TransactionController : Form
    {
        public TransactionController()
        {
            InitializeComponent();
        }

        private void TransactionController_Load(object sender, EventArgs e)
        {

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
