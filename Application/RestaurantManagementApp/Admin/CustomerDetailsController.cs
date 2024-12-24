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

namespace RestaurantManagementApp.Admin
{
    public partial class CustomerDetailsController : Form
    {
        public CustomerDetailsController()
        {
            InitializeComponent();
        }
        API_URl api = new API_URl();
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDetails customerDetails = new CustomerDetails()
                {
                    CustomerId = Convert.ToInt32(txtCustomerID.Text),
                    CustomerBudget = Convert.ToInt32(txtCustomerBudget.Text),
                    Status = txtStatus.Text
                };

                string json = JsonConvert.SerializeObject(customerDetails);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/CustomerDetails", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Csutomer Details added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerDetailsController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add customer details. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string customerDetailsId = txtID.Text;

                if (string.IsNullOrEmpty(customerDetailsId))
                {
                    MessageBox.Show("Please select a customer to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/CustomerDetails/{customerDetailsId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Customer deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerDetailsController_Load(sender, e);
                        txtID.Text = "";
                        txtCustomerID.Text = "";
                        txtCustomerBudget.Text = "";
                        txtStatus.Text = "";
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete customer. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerDetailsId = txtID.Text;

                if (string.IsNullOrEmpty(customerDetailsId))
                {
                    MessageBox.Show("Please select a customer details to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CustomerDetails customerDetails = new CustomerDetails()
                {
                    CustomerId = Convert.ToInt32(txtCustomerID.Text),
                    CustomerBudget = Convert.ToInt32(txtCustomerBudget.Text),
                    Status = txtStatus.Text
                };

                string json = JsonConvert.SerializeObject(customerDetails);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/CustomerDetails/{customerDetailsId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Customer details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerDetailsController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update customer details. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = txtID.Text;

                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Please enter a customer ID to search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"api/Customers/{customerId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var customer = JsonConvert.DeserializeObject<CustomerDetails>(jsonResponse);

                        MessageBox.Show($"Customer Order ID: {customer.CustomerDetailId}" +
                                        $"Customer ID: {customer.CustomerId}\n" +
                                        $"Customer Budget: {customer.CustomerBudget}\n" +
                                        $"Status: {customer.Status}",
                                        "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController ctrlForm = new AdminController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private async void CustomerDetailsController_Load(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/CustomerDetails");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var customersDetails = JsonConvert.DeserializeObject<List<CustomerDetails>>(jsonResponse);

                        dataGridView1.DataSource = customersDetails;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load customer details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells[0].Value.ToString();
                txtCustomerID.Text = row.Cells[1].Value.ToString();
                txtCustomerBudget.Text = row.Cells[2].Value.ToString();
                txtStatus.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
