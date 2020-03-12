using System;
using System.Collections.Generic;

namespace Homework4
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();
            myList.AddFirst(313);
            myList.AddAfter(myList.First,4324);
            myList.AddAfter(myList.First,767);
            myList.ForEach(x => Console.WriteLine(x));
        }
    }
    /*public class Node<T>
    {
        public Node<T> next { get; set; }
        public T data { get; set; }
        public Node() { }
        public Node(T t) { this.data = t; }
    }*/
    public class MyList<T> : System.Collections.Generic.LinkedList<T>
    {
        new public void ForEach(Action<LinkedListNode<T>> action)
        {
            LinkedListNode<T> node = this.First;
            while (node!=null)
            {
                action(node);
                node = node.Next;
            }
        }
    }
}
