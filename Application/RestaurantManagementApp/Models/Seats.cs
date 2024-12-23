using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Models
{
    internal class Seats
    {
        public int SeatId { get; set; }

        public int? BranchId { get; set; }

        public string Status { get; set; }
    }
}
