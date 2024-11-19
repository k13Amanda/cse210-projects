
class Order{


    private List<Product> _productList;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _productList = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _productList.Add(product);
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product Product in _productList)
        {
            packingLabel += $"{Product.GetName()} ({Product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }

    public int GetShippingCost(){ 
        if(_customer.GetAddress().LiveInUsa())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }

    public double GetTotalOrderCost()
    {
        double total = 0;
        foreach(Product product in _productList)
        {
            total += product.GetTotalPriceOfOneProduct();
        }
        total += GetShippingCost();
        return total;
    }

}