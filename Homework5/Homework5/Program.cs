using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("实现已经定义好5种Order。分别是大米，蔬菜，华为手机，工具和衣服");
            Order rice=new Order(1,"大米",2.7);
            Order vegetable = new Order(2, "蔬菜", 1.5);
            Order smartPhone = new Order(3, "华为手机", 3500);
            Order tool = new Order(4, "工具", 120);
            Order clothes = new Order(5, "衣服", 322);
            Console.WriteLine("____________________________________________________________________________________________________");
            OrderItem buyRice=new OrderItem(rice,1,"IzumiSakai", 4);
            OrderItem buyVegetable = new OrderItem(vegetable, 2, "IzumiSakai", 3.5);
            OrderItem buySmartPhone = new OrderItem(smartPhone, 3, "IzumiSakai", 2);
            OrderItem buyTool = new OrderItem(tool, 4, "IzumiSakai", 13);
            OrderItem buyClothes = new OrderItem(clothes, 5, "IzumiSakai", 0.5);
            System.Threading.Thread.Sleep(4500);
            OrderService orderService = new OrderService();
            orderService.addOrderItem(buyRice);
            orderService.addOrderItem(buyVegetable);
            orderService.addOrderItem(buySmartPhone);
            orderService.addOrderItem(buyTool);
            orderService.addOrderItem(buyClothes);
            Console.WriteLine("已经定义好5个OrderItem如下");
            orderService.dispayOrderItem();
            Console.WriteLine("________________________________________________________________________________________________");
            System.Threading.Thread.Sleep(4500);
            Console.WriteLine("调用deleteOrderItem()方法删除一个元素，打印如下");
            orderService.deletOrderItem(2);
            orderService.dispayOrderItem();
            Console.WriteLine("___________________________________________________________________________________________________");
            System.Threading.Thread.Sleep(4500);
            Console.WriteLine("调用sort()方法排序一个元素，打印如下");
            orderService.sort();
            orderService.dispayOrderItem();
            Console.WriteLine("___________________________________________________________________________________________________");
            System.Threading.Thread.Sleep(4500);
            Console.WriteLine("测试结束");
        }
    }
}
