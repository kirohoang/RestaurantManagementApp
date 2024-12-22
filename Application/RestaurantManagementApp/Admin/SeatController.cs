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
    public partial class SeatController : Form
    {
        public SeatController()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            this.Hide();
            adminController.ShowDialog();
            this.Close();
        }
    }
}
