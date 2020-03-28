using System;

public class OrderItem:IComparable
{
    public int orderItemId { get; set; }
    public string client { get; set; }
    public double quantity { get; set; }
    public double totalPrice { get; set; }   
    public Order order { get; set; }
    public OrderItem() { }

    public OrderItem(Order order, int orderItemId, string client, double quantity)
    {
        this.order = order.deepClone();
        this.orderItemId = orderItemId;
        this.client = client;
        this.quantity = quantity;
        this.totalPrice = this.order.price * this.quantity;
    }
    public OrderItem deepClone()
    {
        return new OrderItem(this.order, this.orderItemId, this.client, this.quantity);
    }

    public override string ToString()
    {
        return order.ToString() + "  client: " + this.client + "  quantity: "+this.quantity+"  totalPrice: "+this.totalPrice;
    }

    public int CompareTo(object obj)
    {
        OrderItem orderItem = obj as OrderItem;
        if (orderItem == null)
            throw new Exception("空指针异常");
        if (this.totalPrice > orderItem.totalPrice)
            return 1;
        else if (this.totalPrice == orderItem.totalPrice)
            return 0;
        else
            return -1;
    }
    public override bool Equals(object obj)
    {
        OrderItem orderItem = obj as OrderItem;
        return this.order == orderItem.order && this.orderItemId == orderItem.orderItemId && this.client == orderItem.client
            && this.quantity == orderItem.quantity;
    }
}
