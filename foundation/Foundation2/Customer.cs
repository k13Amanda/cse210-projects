

using System.Reflection;
using System.Runtime.InteropServices;

class Customer{

    private string _customerName;
    private Address _address;

    public Customer(string customerName, Address address)
    {
        _customerName = customerName;
        _address = address;
    }

    public string GetName()
    {
        return _customerName;
    }
    public Address GetAddress()
    {
        return _address;
    }

    public void PrintWhereLive()
    {
        if (_address.LiveInUsa())
        {
            Console.WriteLine(" You live in the USA");
        }
        else
        {
            Console.WriteLine(" You do not live in the USA");
        }
    }



}