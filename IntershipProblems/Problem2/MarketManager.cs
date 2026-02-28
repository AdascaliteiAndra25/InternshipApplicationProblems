using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketProblem
{
    public class MarketManager
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public Customer GetTopCustomer()
        {
            return Customers.OrderByDescending(c => c.Orders.Sum(o => o.CalculateFinalPrice())).FirstOrDefault();
        }

        public Dictionary<string, int> GetPopularProducts()
        {
            return Customers.SelectMany(c => c.Orders)
                .SelectMany(o => o.Items)
                .GroupBy(i => i.ProductName)
                .Select(g => new { Product = g.Key, TotalQuantity = g.Sum(i => i.Quantity) })
                .OrderByDescending(x => x.TotalQuantity)
                .ToDictionary(x => x.Product, x => x.TotalQuantity);

        }
    }
}
