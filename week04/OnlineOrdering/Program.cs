using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123 Maple Street", "Boise", "Idaho", "USA");
        Customer usaCustomer = new Customer("Emma Johnson", usaAddress);
        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(new Product("Wireless Mouse", "WM-104", 24.99m, 2));
        usaOrder.AddProduct(new Product("USB-C Cable", "UC-208", 9.50m, 3));
        usaOrder.AddProduct(new Product("Laptop Stand", "LS-305", 39.99m, 1));

        Address internationalAddress = new Address("45 Queen Street", "Toronto", "Ontario", "Canada");
        Customer internationalCustomer = new Customer("Liam Martin", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Notebook", "NB-402", 6.75m, 4));
        internationalOrder.AddProduct(new Product("Pen Set", "PS-517", 12.00m, 2));

        DisplayOrder(usaOrder, 1);
        DisplayOrder(internationalOrder, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"ORDER {orderNumber}");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine();
    }
}
