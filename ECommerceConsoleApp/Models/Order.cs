using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceConsoleApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
