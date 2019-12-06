using System;
using System.Collections.Generic;

namespace DrinksAndSnacks.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int ReOrderLevel { get; set; }
        public int StockLevel { get; set; }
    }
}
