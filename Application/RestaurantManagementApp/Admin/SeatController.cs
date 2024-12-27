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
    public partial class SeatController : Form
    {
        public SeatController()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            this.Hide();
            adminController.ShowDialog();
            this.Close();
        }
        API_URl api = new API_URl();
        private async void SeatController_Load(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Available");
                cmbStatus.Items.Add("Not Available");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Seats");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var seats = JsonConvert.DeserializeObject<List<Seats>>(jsonResponse);

                        dataGridView1.DataSource = seats;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load seats", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Seats seats = new Seats()
                {
                    BranchId = Convert.ToInt32(txtBranchID.Text),
                    Status = cmbStatus.SelectedItem.ToString(),
                };

                string json = JsonConvert.SerializeObject(seats);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Seats", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Seat added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SeatController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add seat. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Seats seats = new Seats()
                {
                    BranchId = Convert.ToInt32(txtBranchID.Text),
                    Status = cmbStatus.SelectedItem.ToString(),
                };

                string json = JsonConvert.SerializeObject(seats);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Seats/{txtSeatID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Seat updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SeatController_Load(sender, e);
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
                int seatID = int.Parse(txtSeatID.Text);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/Seats/{txtSeatID.Text}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Seat deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SeatController_Load(sender, e);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete seat. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtSeatID.Text = row.Cells[0].Value.ToString();
                txtBranchID.Text = row.Cells[1].Value.ToString();
                cmbStatus.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
