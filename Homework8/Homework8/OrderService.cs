using System;
using System.Collections.Generic;
using System.Linq;

public class OrderService
{
    public List<OrderItem> orderList = new List<OrderItem>();

    public bool addOrderItem(OrderItem orderItem)
    {
        int beforeCount = orderList.Count;
        orderList.Add(orderItem.deepClone());
        return orderList.Count > beforeCount;
    }

    public bool deletOrderItem(int orderItemId)
    {
        int beforeCount = orderList.Count;
        var targetOder = orderList.Where(s => s.orderItemId == orderItemId);
        try
        {
            foreach (OrderItem orderItem in targetOder)
            {
                this.orderList.Remove(orderItem);
            }
        }catch(Exception e)
        {}
        return orderList.Count < beforeCount;
    }
    public void dispayOrderItem()
    {
        for(int i=0;i<orderList.Count;i++)
                Console.WriteLine(orderList[i]);
    }
    public void sort()
    {
        this.orderList.Sort();
    }
}
