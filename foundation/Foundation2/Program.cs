using System;
using System.Collections.Generic; // Ensure you have this for List

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");

        Address address1 = new Address("100 W. 200 S.", "Provo", "Utah", "USA");

        Customer person1 = new Customer("Amanda", address1);

        Product item1 = new Product("Milk", "M6345", 3, 1);
        Product item2 = new Product("Bread", "B1234", 2, 2);
        Product item3 = new Product("Eggs", "E5678", 1.5, 12);

        Order order1 = new Order(person1);
        order1.AddProduct(item1);
        order1.AddProduct(item2);
        order1.AddProduct(item3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.GetTotalOrderCost()}");
    }
}
