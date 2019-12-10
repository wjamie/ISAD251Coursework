using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DrinksAndSnacks.Models
{
    public class Add_Order
    {

        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public int ProductName { get; set; }
        public int Quantity { get; set; }
      

    }
}
