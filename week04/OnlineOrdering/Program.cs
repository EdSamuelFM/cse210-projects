using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================");
        Console.WriteLine();

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Pine Rd", "London", "ENG", "UK");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Maria Garcia", address2);
        Customer customer3 = new Customer("David Johnson", address3);

        // Create products
        Product product1 = new Product("Laptop", "P001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "P002", 29.99, 2);
        Product product3 = new Product("Keyboard", "P003", 59.99, 1);
        Product product4 = new Product("Monitor", "P004", 199.99, 1);
        Product product5 = new Product("Headphones", "P005", 79.99, 3);
        Product product6 = new Product("Webcam", "P006", 49.99, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product6);
        order3.AddProduct(product2);
        order3.AddProduct(product5);

        // Display order details
        List<Order> orders = new List<Order> { order1, order2, order3 };

        foreach (Order order in orders)
        {
            order.DisplayOrderDetails();
        }
    }
}