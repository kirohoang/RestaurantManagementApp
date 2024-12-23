using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Models
{
    internal class CustomerDetails
    {
        public int CustomerDetailId { get; set; }

        public int? CustomerId { get; set; }

        public decimal CustomerBudget { get; set; }

        public string Status { get; set; }
    }
}
