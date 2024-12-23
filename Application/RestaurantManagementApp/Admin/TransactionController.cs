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
    public partial class TransactionController : Form
    {
        public TransactionController()
        {
            InitializeComponent();
        }
        API_URl api = new API_URl();
        private async void TransactionController_Load(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Transactions");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var transactions = JsonConvert.DeserializeObject<List<Transaction>>(jsonResponse);

                        dataGridView1.DataSource = transactions;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load transactions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Transaction transaction = new Transaction()
                {
                    CustomerId = Convert.ToInt32(txtCustomerID.Text),
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    TransactionDate = Convert.ToDateTime(txtDate.Text),
                    TransactionType = txtType.Text,
                    Description = txtDescription.Text
                };

                string json = JsonConvert.SerializeObject(transaction);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Transactions/{txtTransactionID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Seat updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TransactionController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update seat. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int seatID = int.Parse(txtTransactionID.Text);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/Transactions/{txtTransactionID.Text}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Transaction deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TransactionController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete transaction. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtTransactionID.Text = row.Cells[0].Value.ToString();
                txtCustomerID.Text = row.Cells[1].Value.ToString();
                txtAmount.Text = row.Cells[2].Value.ToString();
                txtDate.Text = row.Cells[3].Value.ToString();
                txtType.Text = row.Cells[4].Value.ToString();
                txtDescription.Text = row.Cells[5].Value.ToString();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Transaction transaction = new Transaction()
                {
                    CustomerId = Convert.ToInt32(txtCustomerID.Text),
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    TransactionDate = Convert.ToDateTime(txtDate.Text),
                    TransactionType = txtType.Text,
                    Description = txtDescription.Text
                };

                string json = JsonConvert.SerializeObject(transaction);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Transactions", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Transaction added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TransactionController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add transaction. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
