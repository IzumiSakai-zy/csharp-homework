using System;

public class Order
{
    public int orderId { set; get; }
    public string goodName { set; get; }
    public double price { set; get; }
    public Order() { }

    public Order(int orderId, string goodName, double price)
    {
        this.orderId = orderId;
        this.goodName = goodName;
        this.price = price;
    }

    public Order deepClone()
    {
        return new Order(this.orderId, this.goodName, this.price);
    }

    public override string ToString()
    {
        return "orderId: " + this.orderId + "  goodName: " + this.goodName + "  price: " + this.price;
    }
    public override bool Equals(object obj)
    {
        Order order = obj as Order;
        return this.orderId == order.orderId && this.goodName == order.goodName && this.price == order.price;
    }
}
