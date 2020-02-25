using System;

namespace Homework2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Tag: while (true)
            {
                Console.WriteLine("下面请老师检查作业，请输入一个整数。");
                Console.WriteLine("1 - 作业一，2 - 作业二，3 - 作业三，0-退出检查");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("请输入一个正整数");
                        FindPrimInt test1 = new FindPrimInt(Convert.ToInt32(Console.ReadLine()));
                        test1.printPrim();
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("注：数组已经提前定义，值为{ 2, 4, 54, 323, 4242, 5353, 313, 424, 24, 1, 314, 14, 578 }");
                        MyArray test2 = new MyArray(new int[] { 2, 4, 54, 323, 4242, 5353, 313, 424, 24, 1, 314, 14, 578 },
                            new int[] { 2, 4, 54, 323, 4242, 5353, 313, 424, 24, 1, 314, 14, 578}.Length);
                        Console.WriteLine("数组的最大值是{0}",test2.findMax());
                        Console.WriteLine("数组的最小值是{0}", test2.findMin());
                        Console.WriteLine("数组的总和是{0}", test2.andAll());
                        Console.WriteLine("数组的平均数是{0}", test2.findAverage());
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    case 3:
                        findPrimBetweenAAndB test3 = new findPrimBetweenAAndB(2, 100);
                        Console.Write("2-100的质数有");
                        test3.find();
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    case 0:
                        return;
                        break;
                    default:
                        Console.WriteLine("对不起，你的输入不符合要求，请重新输入");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                }
            }
        }
    }
    class FindPrimInt
    {
        private int a;
        private int[] b;//因数数组
        public FindPrimInt() { }
        public FindPrimInt(int a)
        {
            this.a = a;
            int[] c = new int[this.a];
            int count = 0;
            for (int i = 1; i <= this.a; i++)
            {
                if (this.a % i == 0)
                {
                    c[count] = i;
                    count++;
                }
            }
            this.b = new int[count];
            for (int i = 0; i < count; i++)
                this.b[i] = c[i];
        }
        public bool isPrim(int a)
        {
            bool flag = true;
            if (a == 1)
                return false;
            else if (a == 2)
                return true;
            for (int i = 2; i < a - 1; i++)
            {
                if (a % i == 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public void printPrim()
        {
            Console.Write("这个正整数的质因数是");
            for (int i = 0; i < this.b.Length; i++)
            {
                if (isPrim(b[i]))
                    Console.Write("{0} ", b[i]);
            }
            Console.WriteLine();
        }
    }
    class MyArray
    {
        private int[] array;
        public MyArray() { }
        public MyArray(int[] testArray,int a)
        {
            this.array = new int[a];
            for(int i = 0; i < a; i++)
            {
                this.array[i] = testArray[i];
            }
        }
        public int findMax()
        {
            int temp = this.array[0];
            for(int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] > temp)
                    temp = this.array[i];
            }
            return temp;
        }
        public int findMin()
        {
            int temp = this.array[0];
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] < temp)
                    temp = this.array[i];
            }
            return temp;
        }
        public int andAll()
        {
            int temp = 0;
            foreach (int i in this.array)
                temp += i;
            return temp;
        }
        public double findAverage()
        {
            return andAll() / this.array.Length;
        }
    }
    class findPrimBetweenAAndB
    {
        private int A, B;
        private int[] primeNumber;
        public findPrimBetweenAAndB() { }
        public findPrimBetweenAAndB(int A,int B)
        {
            this.A = A;
            this.B = B;
            primeNumber = new int[this.B - this.A + 1];
            for (int i = 0; i < this.primeNumber.Length; i++)
                primeNumber[i] = A + i;
        }
        public void find()
        {
            for(int i = A; i <= B; i++)
            {
                for(int t = 0; t< this.primeNumber.Length; t++)
                {
                    if (this.primeNumber[t] % i == 0&&this.primeNumber[t]>i)
                        primeNumber[t] = -1;
                }
            }
            foreach(int i in primeNumber)
            {
                if (i != -1)
                    Console.Write("{0} ",i);
            }
        }

    }
}

