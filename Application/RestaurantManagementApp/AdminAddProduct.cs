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
    public partial class AdminAddProduct : Form
    {
        public AdminAddProduct()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminControlPanelForm ctrlForm = new AdminControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }
    }
}
