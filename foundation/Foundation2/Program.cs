using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address("100 W. 200 S.", "Provo", "Utah", "USA");

        Customer person1 = new Customer("Emily", address1);

        Product item1 = new Product("Milk", "M6345", 3, 1);
        Product item2 = new Product("Bread", "B234", 2, 2);
        Product item3 = new Product("Eggs", "E5678", 1.5, 1);

        Order order1 = new Order(person1);
        order1.AddProduct(item1);
        order1.AddProduct(item2);
        order1.AddProduct(item3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.GetTotalOrderCost()}");
        

        // Order 2
        Address address2 = new Address("123 Maple Avenue", "Toronto", "Ontario", "Canada");

        Customer person2 = new Customer("John", address2);

        Product item7 = new Product("Ham", "H739", 3, 1);
        Product item8 = new Product("Apple", "A259", .50, 5);
        Product item9 = new Product("Bread", "B234", 2, 2);

        Order order2 = new Order(person2);
        order2.AddProduct(item7);
        order2.AddProduct(item8);
        order2.AddProduct(item9);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order2.GetTotalOrderCost()}");
    }
}
