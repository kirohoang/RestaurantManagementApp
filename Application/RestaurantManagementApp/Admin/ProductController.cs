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
    public partial class ProductController : Form
    {
        public ProductController()
        {
            InitializeComponent();
        }

        API_URl api = new API_URl();
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int price = int.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                Product product = new Product()
                {
                    ProductName = txtName.Text,
                    Price = price,
                    Quantity = quantity,
                    Description = txtDescription.Text,
                    Image = txtImage.Text,
                    Type = cmbType.SelectedItem.ToString()
                };

                string json = JsonConvert.SerializeObject(product);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/Products", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductController_Load(sender, e);
                        txtProductID.Text = "";
                        txtName.Text = "";
                        txtPrice.Text = "";
                        txtQuantity.Text = "";
                        txtDescription.Text = "";
                        txtImage.Text = "";
                        cmbType.Text = "";
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add product. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminController ctrlForm = new AdminController();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtProductID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPrice.Text = row.Cells[2].Value.ToString();
                txtQuantity.Text = row.Cells[3].Value.ToString();
                txtDescription.Text = row.Cells[4].Value.ToString();
                txtImage.Text = row.Cells[5].Value.ToString();
                cmbType.Text = row.Cells[6].Value.ToString();

                if (!string.IsNullOrEmpty(txtImage.Text) && System.IO.File.Exists(txtImage.Text))
                {
                    pictureBox1.Image = Image.FromFile(txtImage.Text);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductID.Text);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/Products/{productId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductController_Load(sender, e);
                        txtProductID.Text = "";
                        txtName.Text = "";
                        txtPrice.Text = "";
                        txtQuantity.Text = "";
                        txtDescription.Text = "";
                        txtImage.Text = "";
                        cmbType.Text = "";
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete product. Response: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int price = int.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);

                Product product = new Product()
                {
                    ProductName = txtName.Text,
                    Price = price,
                    Quantity = quantity,
                    Description = txtDescription.Text,
                    Image = txtImage.Text,
                    Type = cmbType.SelectedItem.ToString()
                };

                string json = JsonConvert.SerializeObject(product);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"api/Products/{txtProductID.Text}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Product updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductController_Load(sender, e);
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

        private async void ProductController_Load(object sender, EventArgs e)
        {
            try
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("Food");
                cmbType.Items.Add("Drink");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Products");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);

                        dataGridView1.DataSource = products;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                txtImage.Text = imagePath;
            }
        }
    }
}
