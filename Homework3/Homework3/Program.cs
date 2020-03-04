using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("任务一______________________________________________________________________________________________");
            Shape rectangle = new Rectangle(5, 2);
            Console.WriteLine("长方形的面积是" + rectangle.getArea());
            Shape square = new Square(7);
            Console.WriteLine("正方形的面积是" + square.getArea());
            Shape triangle = new Triangle(3, 4, 5);
            Console.WriteLine("三角形的面积是" + triangle.getArea());
            Console.WriteLine("任务二______________________________________________________________________________________________");
            double s = 0;
            ShapeFactory ShapeFactory = new ShapeFactory();
            /*Random random = new Random();
            switch (random.Next(0, 3) % 1 + 1)
            {
                case 1:
                    return new Rectangle(random.Next(1, 100), random.Next(1, 100));
                    break;
                case 2:
                    return new Square(random.Next(1, 100));
                    break;
                case 3:
                    return new Triangle(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));
                    break;
                default:
                    return new Rectangle(random.Next(1, 100), random.Next(1, 100));
            }*/
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (random.Next(0, 3) % 1 + 1)
                {
                    case 1:
                        s += ShapeFactory.getShapeObject("Rectangle").getArea();
                        break;
                    case 2:
                        s += ShapeFactory.getShapeObject("Square").getArea();
                        break;
                    case 3:
                        s += ShapeFactory.getShapeObject("Triangle").getArea();
                        break;
                }
            }
            Console.WriteLine("总面积是" + s);
        }
        public interface Shape
        {
            double getArea();
            bool isLegal();
        }
        public class Rectangle : Shape
        {
            protected double parameter1, parameter2;
            public double length { get => parameter1; set => parameter1 = value; }
            public double height { get => parameter2; set => parameter2 = value; }
            public Rectangle() { }
            public Rectangle(double parameter1, double parameter2)
            {
                this.parameter1 = parameter1;
                this.parameter2 = parameter2;
            }
            public bool isLegal() { 
                return parameter1>0&&parameter2>0;
            }
            public double getArea()
            {
                if (this.isLegal())
                    return this.parameter1 * this.parameter2;
                else
                    return -1;
            }
        }
        public class Square : Rectangle
        { 
            public Square() { }
            public Square(double parameter1) : base(parameter1, parameter1) { }
        }
        public class Triangle : Shape
        {
            private double side1, side2, side3;
            public Triangle() { }
            public Triangle(double parameter1, double parameter2,double parameter3)
            {
                this.side1 = parameter1;
                this.side2 = parameter2;
                this.side3 = parameter3;
            }
            public bool isLegal()
            {
                bool bool1 = this.side1 + this.side2 > this.side3;
                bool bool2 = this.side1 + this.side3 > this.side2;
                bool bool3 = this.side3 + this.side2 > this.side1;
                bool bool4 = this.side1 > 0 && this.side2 > 0 && this.side3 > 0;
                return bool1 && bool2 && bool3&&bool4;
            }
            public double getArea()
            {
                double p = (this.side3 + this.side2 + this.side1) / 2;
                if (this.isLegal())
                    return Math.Pow(p * (p - this.side1) * (p - this.side2) * (p - this.side3), 0.5);
                else
                    return -1;
            }
        }
        class ShapeFactory
        {
            public Shape getShapeObject(String s)
            {
                Random random = new Random();
                switch (s)
                {
                    case "Rectangle":
                        return new Rectangle(random.Next(1, 100), random.Next(1, 100));
                    case "Square":
                        return new Square(random.Next(1, 100));
                    case "Triangle":
                        return new Triangle(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));
                    default:
                        throw new Exception("抱歉你输入的形状不符合要求");
                }
            }
        }
    }
}
