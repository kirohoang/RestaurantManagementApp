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
    public partial class OrderDetailsController : Form
    {
        public OrderDetailsController()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController ctrlForm = new AdminController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }
        API_URl api = new API_URl();
        private async void OrderDetailsController_Load(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/OrderDetails");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var orderDetails = JsonConvert.DeserializeObject<List<OrderDetails>>(jsonResponse);

                        dataGridView1.DataSource = orderDetails;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load order detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                OrderDetails orderDetails = new OrderDetails
                {
                    OrderId = Convert.ToInt32(txtOrderID.Text),
                    ProductName = txtProductName.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    Price = Convert.ToDecimal(txtPrice.Text)
                };

                string json = JsonConvert.SerializeObject(orderDetails);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/OrderDetails", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order Details added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderDetailsController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add order details. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDetails orderDetails = new OrderDetails
                {
                    OrderId = Convert.ToInt32(txtOrderID.Text),
                    ProductName = txtProductName.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    Price = Convert.ToDecimal(txtPrice.Text)
                };

                string json = JsonConvert.SerializeObject(orderDetails);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/OrderDetails/{txtOrderDetailsID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderDetailsController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update product. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int orderDetailsID = int.Parse(txtOrderDetailsID.Text);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/OrderDetails/{orderDetailsID}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order details deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderDetailsController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete order details. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtOrderDetailsID.Text = row.Cells[0].Value.ToString();
                txtOrderID.Text = row.Cells[1].Value.ToString();
                txtProductName.Text = row.Cells[2].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();
                txtPrice.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
