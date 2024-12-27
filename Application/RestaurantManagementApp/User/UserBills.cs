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
    public partial class UserBills : Form
    {
        public UserBills()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            UserControlPanelForm ctrlForm = new UserControlPanelForm();
            this.Hide();
            ctrlForm.ShowDialog();
            this.Close();
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            UserMenuProductCheck MenuForm = new UserMenuProductCheck();
            this.Hide();
            MenuForm.ShowDialog();
            this.Close();
        }

        private void lblBooking_Click(object sender, EventArgs e)
        {
            UserBooking BookingForm = new UserBooking();
            this.Hide();
            BookingForm.ShowDialog();
            this.Close();
        }

        private void lblLocation_Click(object sender, EventArgs e)
        {
            UserLocationBranchCheck location = new UserLocationBranchCheck();
            this.Hide();
            location.ShowDialog();
            this.Close();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            UserDetails Detailsform = new UserDetails();
            this.Hide();
            Detailsform.ShowDialog();
            this.Close();
        }

        private void lblEdit_Reset_Click(object sender, EventArgs e)
        {

        }
        API_URl api = new API_URl();
        private async void UserBills_Load(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Session.orderID.ToString());
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"api/OrderDetails/{Session.orderID}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var orderDetails = JsonConvert.DeserializeObject<OrderDetails>(jsonResponse);

                        txtProductName.Text = orderDetails.ProductName;
                        txtQuantity.Text = orderDetails.Quantity.ToString();
                        txtPrice.Text = orderDetails.Price.ToString();
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
    }
}
