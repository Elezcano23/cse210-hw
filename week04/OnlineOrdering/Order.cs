public class Order
{
    private const decimal DomesticShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;

    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = _customer.LivesInUSA() ? DomesticShippingCost : InternationalShippingCost;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        return total;
    }

    public string GetPackingLabel()
    {
        List<string> lines = new List<string>();

        foreach (Product product in _products)
        {
            lines.Add($"{product.GetName()} - {product.GetProductId()}");
        }

        return string.Join("\n", lines);
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetShippingAddress()}";
    }
}
