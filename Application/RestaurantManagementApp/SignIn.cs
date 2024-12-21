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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals("admin") && txtPassWord.Text.Equals("admin"))
            {
                AdminControlPanelForm ctrlForm = new AdminControlPanelForm();
                this.Hide();
                ctrlForm.ShowDialog();
                this.Close();
            }else if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("You have to input your Account Username and Passowrd");
            }

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUp sign = new SignUp();
            this.Hide();
            sign.ShowDialog();
            this.Close();

        }
    }
}
