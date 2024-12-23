using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Models
{
    internal class Order
    {
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public int? SeatId { get; set; }

        public int? BranchId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Ispayment { get; set; }

        public string PaymentMethod { get; set; }
    }
}
