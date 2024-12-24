using RestaurantManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RestaurantManagementApp.API_URL;

namespace RestaurantManagementApp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        API_URl api = new API_URl();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isNumber(string input)
        {
            int n = 0;
            return int.TryParse(input, out n);
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtPhone.Text) ||
                    isNumber(txtPhone.Text) == false ||
                    txtPhone.Text.Length < 10 || txtPhone.Text.Length > 10)
                {
                    MessageBox.Show("Please fill all the fields correctly");
                    return;
                }

                Customer customer = new Customer()
                {
                    CustomerName = txtName.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text
                };

                string json = JsonConvert.SerializeObject(customer);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Customers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response to get the created customer with the CustomerId
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Customer createdCustomer = JsonConvert.DeserializeObject<Customer>(responseBody);

                        CustomerDetails customerDetails = new CustomerDetails()
                        {
                            CustomerId = createdCustomer.CustomerId, // Use the CustomerId from the created customer
                            CustomerBudget = 0,
                            Status = "Active"
                        };

                        string json1 = JsonConvert.SerializeObject(customerDetails);

                        HttpContent customerDetailsContent = new StringContent(json1, Encoding.UTF8, "application/json");
                        HttpResponseMessage responseCustomerDetails = await client.PostAsync("api/CustomerDetails", customerDetailsContent);

                        if (responseCustomerDetails.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Sign up successfully");

                            SignIn sign = new SignIn();
                            this.Hide();
                            sign.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to create customer details");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sign up failed");
                    }
                }
            }
            catch (Exception ex)
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
