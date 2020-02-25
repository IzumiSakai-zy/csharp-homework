using System;
namespace cho1
{
    class exampleClass
    {
        public static void Main(string[] args)
        {
            double a, b;
             string s;
             Console.WriteLine("请输入一个数");
             a = Double.Parse(Console.ReadLine());
             Console.WriteLine("请输入要进行的运算");
             s = Console.ReadLine();
             Console.WriteLine("请再输入一个数");
             b = Double.Parse(Console.ReadLine());
             Console.WriteLine("你得到的结果是");
             switch (s)
             {
                 case "+": Console.WriteLine(a + b);break;
                 case "-": Console.WriteLine(a - b); break;
                 case "*": Console.WriteLine(a * b); break;
                 case "/": Console.WriteLine(a / b); break;
             }
             /*for(int i=0;i<100;i++)
                 Console.WriteLine(new Random().NextDouble());
             Console.WriteLine(Convert.ToInt32("67"));
             */
        }
    }
}
