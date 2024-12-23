﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementApp.Models
{
    internal class OrderDetails
    {
        public int OrderDetailsId { get; set; }

        public int? OrderId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
