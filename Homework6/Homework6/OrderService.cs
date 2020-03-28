using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

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
    public void export(String path) 
    {
        OrderItem[] orderItems = new OrderItem[5];
        for (int i = 0; i < orderList.Count; i++)
            orderItems[i] = orderList[i].deepClone();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderItem[]));
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            xmlSerializer.Serialize(fs, orderItems);
        }
    }
    public void import(String path)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderItem[]));
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            OrderItem[] orderItems = (OrderItem[])xmlSerializer.Deserialize(fs);
            Array.ForEach(orderItems, p => Console.WriteLine(p));
        }
    }
}
