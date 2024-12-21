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
    public partial class Branch : Form
    {
        public Branch()
        {
            InitializeComponent();
        }

        private void Branch_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            AdminControlPanelForm ctrlForm = new AdminControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }
    }
}
