using Branch1;
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
    public partial class UserBooking : Form
    {
        public UserBooking()
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
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblLocation_Click(object sender, EventArgs e)
        {
            UserLocationBranchCheck location = new UserLocationBranchCheck();
            this.Hide();
            location.ShowDialog();
            this.Close();
        }

        private void lblEdit_reset_Click(object sender, EventArgs e)
        {
            UserBills bill = new UserBills();
            this.Hide();
            bill.ShowDialog();
            this.Close();
        }

        private async void btnAgree_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order()
                {
                    CustomerId = int.Parse(txtCustomerID.Text),
                    ProductId = int.Parse(Session.product_id),
                    BranchId = int.Parse(txtBranchID.Text),
                    SeatId = int.Parse(txtSeat.Text),
                    OrderDate = bookingDate.Value,
                    PaymentMethod = txtPaymentMethod.Text,
                    Ispayment = "True"
                };

                Seats seatUpdate = new Seats()
                {
                    SeatId = int.Parse(txtSeat.Text),
                    BranchId = int.Parse(txtBranchID.Text),
                    Status = "Not Available"
                };

                string jsonOrder = JsonConvert.SerializeObject(order);
                string jsonSeat = JsonConvert.SerializeObject(seatUpdate);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api.api_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent contentOrder = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
                    HttpContent contentSeat = new StringContent(jsonSeat, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.GetAsync($"api/Seats/{txtSeat.Text}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var seatTaken = JsonConvert.DeserializeObject<Seats>(jsonResponse);

                        if (seatTaken.Status == "Not Available")
                        {
                            MessageBox.Show("Seat is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            // Add Order
                            HttpResponseMessage responseAddOrder = await client.PostAsync("api/Orders", contentOrder);
                            if (responseAddOrder.IsSuccessStatusCode)
                            {
                                string orderResponse = await responseAddOrder.Content.ReadAsStringAsync();
                                var createdOrder = JsonConvert.DeserializeObject<Order>(orderResponse);

                                // Update Seat Status
                                HttpResponseMessage responseUpdateSeat = await client.PutAsync($"api/Seats/{txtSeat.Text}", contentSeat);

                                // Add OrderDetails
                                OrderDetails orderDetails = new OrderDetails()
                                {
                                    OrderId = createdOrder.OrderId,
                                    ProductName = txtProductName.Text,
                                    Quantity = int.Parse(txtQuantity.Text),
                                    Price = decimal.Parse(txtQuantity.Text) * Session.price
                                };
                                Session.orderID = createdOrder.OrderId.ToString();
                                string jsonOrderDetails = JsonConvert.SerializeObject(orderDetails);
                                HttpContent contentOrderDetails = new StringContent(jsonOrderDetails, Encoding.UTF8, "application/json");
                                HttpResponseMessage responseAddOrderDetails = await client.PostAsync("api/OrderDetails", contentOrderDetails);
                                MessageBox.Show("Ordered Sucessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        API_URl api = new API_URl();
        private async void UserBooking_Load(object sender, EventArgs e)
        {
            txtCustomerID.Text = Session.Id;
            txtProductName.Text = Session.product_name;
            txtSeat.Text = Session.seatID;
            txtBranchID.Text = Session.brandID;
            Session.quantity = txtQuantity.Text;
            txtPaymentMethod.Text = "Cash";
            txtIsPayment.Text = "False";

        }
        private void btnBranch_Click(object sender, EventArgs e)
        {
            UserLocationBranchCheck location = new UserLocationBranchCheck();
            this.Hide();
            location.ShowDialog();
            this.Close();
        }
    }
}
