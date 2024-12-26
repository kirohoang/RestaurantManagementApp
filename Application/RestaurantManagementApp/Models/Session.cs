using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Models
{
    public static class Session
    {
        public static string Id { get; set; }
        public static string orderID { get; set; }
        public static string Username { get; set; }
        public static string brandID { get; set; }
        public static string seatID { get; set; }
        public static string quantity { get; set; }
        public static string product_name { get; set; }
        public static string product_id { get; set; }
        public static decimal price { get; set; }
    }
}
