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
    public partial class OrderController : Form
    {
        public OrderController()
        {
            InitializeComponent();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        API_URl api = new API_URl();
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController ctrlForm = new AdminController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private async void OrderController_Load(object sender, EventArgs e)
        {
            try
            {
                cmbIsPayment.Items.Clear();
                cmbIsPayment.Items.Add("Yes");
                cmbIsPayment.Items.Add("No");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Orders");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var order = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);

                        dataGridView1.DataSource = order;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load orders", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Order order = new Order()
                {
                    CustomerId = Convert.ToInt32(txtCustomerID.Text),
                    ProductId = Convert.ToInt32(txtProductID.Text),
                    SeatId = Convert.ToInt32(txtSeatID.Text),
                    BranchId = Convert.ToInt32(txtBranchID.Text),
                    OrderDate = Convert.ToDateTime(txtOrderDate.Text),
                    Ispayment = cmbIsPayment.SelectedItem.ToString(),
                    PaymentMethod = txtPayMethod.Text
                };

                string json = JsonConvert.SerializeObject(order);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Orders", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add order. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Order order = new Order()
                {
                    Ispayment = cmbIsPayment.SelectedItem.ToString(),
                    PaymentMethod = txtPayMethod.Text
                };

                string json = JsonConvert.SerializeObject(order);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Orders/{txtOrderID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderController_Load(sender, e);
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
                int orderID = int.Parse(txtOrderID.Text);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/Orders/{orderID}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete order. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtOrderID.Text = row.Cells[0].Value.ToString();
                txtCustomerID.Text = row.Cells[1].Value.ToString();
                txtProductID.Text = row.Cells[2].Value.ToString();
                txtSeatID.Text = row.Cells[3].Value.ToString();
                txtBranchID.Text = row.Cells[4].Value.ToString();
                txtOrderDate.Text = row.Cells[5].Value.ToString();
                cmbIsPayment.Text = row.Cells[6].Value.ToString();
                txtPayMethod.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
