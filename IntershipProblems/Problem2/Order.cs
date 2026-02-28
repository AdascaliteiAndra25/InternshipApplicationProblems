using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketProblem
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
   
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public decimal CalculateFinalPrice()
        {
            decimal total = Items.Sum(x => x.Price * x.Quantity);
            if (total > 500)
            {
                total *= 0.9m;
            }
            return total;
        }
    }
}
