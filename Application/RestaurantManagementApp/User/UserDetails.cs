using Newtonsoft.Json;
using RestaurantManagementApp.API_URL;
using RestaurantManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementApp
{
    public partial class UserDetails : Form
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserControlPanelForm ctrlForm = new UserControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            UserTransactions transactions = new UserTransactions();
            this.Hide();
            transactions.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You're logged out", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SignIn signIn = new SignIn();
            this.Hide();
            signIn.ShowDialog();
            this.Close();
        }
        API_URl api = new API_URl();
        private async void UserDetails_Load(object sender, EventArgs e)
        {
            try
            {
                string customerUsername = Session.Username;

                if (string.IsNullOrEmpty(customerUsername))
                {
                    MessageBox.Show("Please enter a customer ID to search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responseCustomer = await client.GetAsync($"api/Customers/get-customer-by-username/{customerUsername}");


                    if (responseCustomer.IsSuccessStatusCode)
                    {
                        string jsonResponseCustomer = await responseCustomer.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<Customer>(jsonResponseCustomer);

                        HttpResponseMessage responseCustomerDetails = await client.GetAsync($"api/CustomerDetails/get-customer-details-by-customer-id/{customer.CustomerId}");
                        string jsonResponseCustomerDetail = await responseCustomerDetails.Content.ReadAsStringAsync();
                        var customerDetails = JsonConvert.DeserializeObject<CustomerDetails>(jsonResponseCustomerDetail);

                        txtID.Text = Convert.ToString(customer.CustomerId);
                        Session.Id = Convert.ToString(customer.CustomerId);
                        txtName.Text = customer.CustomerName;
                        txtMail.Text = customer.Email;
                        txtPhone.Text = customer.Phone;
                        txtAddress.Text = customer.Address;

                        Session.Id = Convert.ToString(customer.CustomerId);
                        if (responseCustomerDetails.IsSuccessStatusCode)
                        {
                            txtBudget.Text = Convert.ToString(customerDetails.CustomerBudget);
                            txtStatus.Text = customerDetails.Status;
                        }
                        else
                        {
                            MessageBox.Show("Customer Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Customer not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
