using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void addOrderItemTest()
        {
            OrderService orderService = new OrderService();
            Order rice = new Order(1, "大米", 2.7);
           OrderItem buyRice = new OrderItem(rice, 2, "IzumiSakai", 3.5);
           orderService.addOrderItem(buyRice);
            Assert.IsNotNull(orderService.orderList[0]);
        }

        [TestMethod()]
        public void deletOrderItemTest()
        {
            OrderService orderService = new OrderService();
            Order rice = new Order(1, "大米", 2.7);
            OrderItem buyRice = new OrderItem(rice, 2, "IzumiSakai", 3.5);
            orderService.addOrderItem(buyRice);
            orderService.deletOrderItem(0);
            Assert.AreNotSame(orderService.orderList[0], buyRice);
        }

        [TestMethod()]
        public void dispayOrderItemTest()
        {
            OrderService orderService = new OrderService();
            Order rice = new Order(1, "大米", 2.7);
            OrderItem buyRice = new OrderItem(rice, 2, "IzumiSakai", 3.5);
            orderService.addOrderItem(buyRice);
            Assert.IsNotNull(orderService.orderList[0]);
        }

        [TestMethod()]
        public void sortTest()
        {
            OrderService orderService = new OrderService();
            Order tool = new Order(4, "工具", 120);
            Order clothes = new Order(5, "衣服", 322);
            OrderItem buyTool = new OrderItem(tool, 4, "IzumiSakai", 13);
            OrderItem buyClothes = new OrderItem(clothes, 5, "IzumiSakai", 0.5);
            orderService.addOrderItem(buyTool);
            orderService.addOrderItem(buyClothes);
            orderService.sort();
            OrderItem[] expect = new OrderItem[] { buyClothes,buyTool};
            OrderItem[] fact = new OrderItem[] { orderService.orderList[1], orderService.orderList[0] };
            Assert.AreEqual( expect,fact);
        }

        [TestMethod()]
        public void exportTest(String path)
        {
            OrderService orderService = new OrderService();
            Order rice = new Order(1, "大米", 2.7);
            OrderItem buyRice = new OrderItem(rice, 2, "IzumiSakai", 3.5);
            orderService.addOrderItem(buyRice);
            OrderItem[] orderItems = new OrderItem[1];
            for (int i = 0; i < orderService.orderList.Count; i++)
                orderItems[i] = orderService.orderList[i].deepClone();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderItem[]));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderItems);
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void importTest(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderItem[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                OrderItem[] orderItems = (OrderItem[])xmlSerializer.Deserialize(fs);
                Array.ForEach(orderItems, p => Console.WriteLine(p));
            }
            Assert.Fail();
        }
    }
}