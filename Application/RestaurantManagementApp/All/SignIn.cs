using RestaurantManagementApp.All;
using RestaurantManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
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
                AdminController ctrlForm = new AdminController();
                this.Hide();
                ctrlForm.ShowDialog();
                this.Close();
            }
            else if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("You have to input your Account Username and Password");
                return;
            }
            string connectionString = "Server=KIROLAPTOP\\SQLEXPRESS01;Database=FinalTerm;Trusted_connection=true;TrustServerCertificate=true";
            string query = "SELECT COUNT(1) FROM Customers WHERE Username=@Username AND Password=@Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", txtUserName.Text);
                command.Parameters.AddWithValue("@Password", txtPassWord.Text);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    Session.Username = txtUserName.Text;
                    UserControlPanelForm userControlPanel = new UserControlPanelForm();
                    this.Hide();
                    userControlPanel.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUp sign = new SignUp();
            this.Hide();
            sign.ShowDialog();
            this.Close();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            EnterMail enterEmail = new EnterMail();
            enterEmail.ShowDialog();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            txtUserName.Select();
        }
    }
}
