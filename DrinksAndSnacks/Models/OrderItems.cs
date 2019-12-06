using System;
using System.Collections.Generic;

namespace DrinksAndSnacks.Models
{
    public partial class OrderItems
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
