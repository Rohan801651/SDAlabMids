using System; /// (LSP, SRP)

public class Order
{
    public string orderName { get; set; }
    public int price { get; set; }
    public Order(string orderName, int price)
    {
        this.orderName = orderName;
        this.price = price;
    }
}

public interface IOrder
{
    public void calculateShippingCost();
    public void processOrder(Order order);
}

public class StandardShipping : IOrder
{
    
    public void calculateShippingCost() {
        // calculate cost
        Console.WriteLine("cost = 100");
    }

    public void processOrder(Order order) {
        Console.WriteLine(order.orderName+" send on Standard way ");
    }
    
}

public class ExpressShipping : IOrder
{
    public void calculateShippingCost() {
        // calculate cost
        Console.WriteLine("cost = 500");
    }

    public void processOrder(Order order) {
        Console.WriteLine(order.orderName+" send on Express way ");
    }
}

public class OrderProcessor {
    
    public void sendOrder(IOrder order, Order prods) {
        order.calculateShippingCost();
        order.processOrder(prods);
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order("Laptop", 5633);
        OrderProcessor processor = new OrderProcessor();

        processor.sendOrder(new ExpressShipping(), order);
        
    }
}
/*
Question # 06:
Order Processing System (LSP, SRP)

Background:

An e-commerce platform processes customer orders. The system should:

Handle different order types:
Standard orders (shipped via regular mail).
Express orders (shipped via priority courier).
Calculate shipping costs for each order type.
Ensure order processing logic is separate from cost calculation.
Task:

Implement the Liskov Substitution Principle (LSP) so all order types can be used interchangeably in the processing system.
Apply the Single Responsibility Principle (SRP) to ensure classes have a single responsibility (e.g., separate order processing from cost calculation).
Your solution should include at least 3-4 classes/interfaces (e.g., for orders and processing).

*/