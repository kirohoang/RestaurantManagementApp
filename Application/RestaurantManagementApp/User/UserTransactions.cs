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
    public partial class UserTransactions : Form
    {
        public UserTransactions()
        {
            InitializeComponent();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void UserTransactions_Load(object sender, EventArgs e)
        {
            txtID.Text = Session.Id;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBudget.Text = string.Empty;
        }
        API_URl api = new API_URl();
        private async void btnRechargeBudget_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = txtID.Text;

                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Please select a customer to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CustomerDetails customerDetails = new CustomerDetails
                {
                    CustomerBudget = decimal.Parse(txtBudget.Text),
                };

                string json = JsonConvert.SerializeObject(customerDetails);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/CustomerDetails/update-budget/{txtID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Customer updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update customer. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
