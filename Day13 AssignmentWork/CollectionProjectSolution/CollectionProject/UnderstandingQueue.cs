using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionProject
{
    class UnderstandingQueue
    {
        Queue<string> myqueue;
        public UnderstandingQueue()
        {
            myqueue = new Queue<string>();
        }
        void AddItemsToQueue()
        {
            //mystack.Push("Red");
            //mystack.Push("Green");
            //mystack.Push("Black");
            //mystack.Push("Krishna");
            myqueue.Enqueue("Red");
            myqueue.Enqueue("blue");
            myqueue.Enqueue("green");
            myqueue.Enqueue("yellow");

        }
        void PrintQueue()
        {
            foreach (var item in myqueue)
            {
                Console.WriteLine(item);
            }
            while (myqueue.Count > 0)
            {
                Console.WriteLine(myqueue.Dequeue());
            }
            Console.WriteLine(myqueue.Count);

        }
        static void Main(string[] a)
        {
            UnderstandingQueue understandingQueue = new UnderstandingQueue();
            understandingQueue.AddItemsToQueue();
            understandingQueue.PrintQueue();
            Console.ReadKey();
        }
    }
}
