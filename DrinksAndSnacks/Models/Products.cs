using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace DrinksAndSnacks.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        [JsonIgnore]
        public int ReOrderLevel { get; set; }
        public int StockLevel { get; set; }
      
    
    }
}
