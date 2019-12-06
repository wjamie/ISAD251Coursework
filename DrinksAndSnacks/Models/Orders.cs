using System;
using System.Collections.Generic;

namespace DrinksAndSnacks.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
