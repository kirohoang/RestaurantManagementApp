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

namespace RestaurantManagementApp.All
{
    public partial class EnterMail : Form
    {
        public EnterMail()
        {
            InitializeComponent();
        }

        API_URl api = new API_URl();

        // Send OTP to Email
        private async void btnGetOTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Please enter your email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".com"))
                {
                    MessageBox.Show("Please enter a valid email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Customer customerEmail = new Customer()
                {
                    Email = txtEmail.Text
                };
                string json = JsonConvert.SerializeObject(customerEmail);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"api/Customers/{txtEmail.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Please check your email to get your OTP", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnCheckOTP.Enabled = true;
                        txtOTP.Enabled = true;
                    }
                    else
                    {
                        // Log the response for debugging
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Email not found. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCheckOTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOTP.Text))
                {
                    MessageBox.Show("Please enter your email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtOTP.Text.Length != 6)
                {
                    MessageBox.Show("Please enter a valid email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"api/Customers/check-otp/{txtOTP.Text}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Correct OTP", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnConfirm.Enabled = true;
                        txtNewPassword.Enabled = true;
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Email not found. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter your new password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Thay đổi thông báo cảnh báo
                return;
            }

            Customer customer = new Customer()
            {
                Password = txtNewPassword.Text
            };
            string json = JsonConvert.SerializeObject(customer);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(api.api_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"api/Customers/update-password/{txtEmail.Text}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync(); // Ghi lại nội dung phản hồi để gỡ lỗi
                    MessageBox.Show($"Failed to update password. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Thay đổi thông báo lỗi
                }
            }

        }

        private void EnterMail_Load(object sender, EventArgs e)
        {
            txtOTP.Enabled = false;
            txtNewPassword.Enabled = false;
            btnCheckOTP.Enabled = false;
            btnConfirm.Enabled = false;
        }
    }
}
