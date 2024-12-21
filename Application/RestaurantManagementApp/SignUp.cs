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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                SignIn sign = new SignIn();
                this.Hide();
                sign.ShowDialog();
                this.Close();
            }
             catch(Exception ex)
            {
                MessageBox.Show("Can't create" + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SignIn sign = new SignIn();
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }
    }
}
