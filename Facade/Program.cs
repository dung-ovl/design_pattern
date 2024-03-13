using System;

// Inventory Service
class InventoryService
{
    public void UpdateInventory(string productId, int quantity)
    {
        Console.WriteLine($"Updating inventory for product {productId} with quantity {quantity}");
    }
}

// Payment Service
class PaymentService
{
    public void ProcessPayment(string paymentMethod, double amount)
    {
        Console.WriteLine($"Processing {paymentMethod} payment of amount {amount}");
    }
}

// Shipping Service
class ShippingService
{
    public void ShipOrder(string orderId, string shippingAddress)
    {
        Console.WriteLine($"Shipping order {orderId} to address {shippingAddress}");
    }
}

// Order Facade
class OrderFacade
{
    private InventoryService _inventoryService;
    private PaymentService _paymentService;
    private ShippingService _shippingService;

    public OrderFacade()
    {
        _inventoryService = new InventoryService();
        _paymentService = new PaymentService();
        _shippingService = new ShippingService();
    }

    public void PlaceOrder(string productId, int quantity, string paymentMethod, double amount, string shippingAddress)
    {
        _inventoryService.UpdateInventory(productId, quantity);
        _paymentService.ProcessPayment(paymentMethod, amount);
        _shippingService.ShipOrder(Guid.NewGuid().ToString(), shippingAddress);
        Console.WriteLine("Order placed successfully!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Client code
        OrderFacade orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("12345", 2, "Credit Card", 100.50, "123 Main St, City, Country");
    }
}
