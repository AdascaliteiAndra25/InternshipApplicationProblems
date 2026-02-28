using System;

namespace SieMarketProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new MarketManager();

            // customers
            var alice = new Customer(1, "Alice");
            var bob = new Customer(2, "Bob");

            // Alice's order
            var order1 = new Order(101, alice);
            order1.AddItem(new OrderItem("Laptop", 1, 1200m));
            order1.AddItem(new OrderItem("Mouse", 2, 50m));
            alice.Orders.Add(order1);

            // Bob's ordr
            var order2 = new Order(102, bob);
            order2.AddItem(new OrderItem("Headphones", 3, 80m));
            order2.AddItem(new OrderItem("Keyboard", 1, 150m));
            bob.Orders.Add(order2);

            store.AddCustomer(alice);
            store.AddCustomer(bob);

            // total orders for Alice & Bob
            Console.WriteLine($"Alice's final price: {order1.CalculateFinalPrice()}");
            Console.WriteLine($"Bob's final price: {order2.CalculateFinalPrice()}");

            // Top customer
            var topCustomer = store.GetTopCustomer();
            Console.WriteLine($"Top customer: {topCustomer.Name}");

            // popular products
            var popularProducts = store.GetPopularProducts();
            Console.WriteLine("Popular products:");
            foreach (var product in popularProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value} sold");
            }
        }
    }
}