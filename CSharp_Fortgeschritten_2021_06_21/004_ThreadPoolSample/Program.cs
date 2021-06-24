using System;
using System.Threading;

namespace _004_ThreadPoolSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread exisitiert schon -> Bei QueueUserWorkItem startet der Thread sofort mit dem Ablauf
            ThreadPool.QueueUserWorkItem(Methode1);
            ThreadPool.QueueUserWorkItem(Methode2);
            ThreadPool.QueueUserWorkItem(Methode3);
            Console.ReadKey();
        }


        static void Methode1(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.WriteLine("#");
            }
        }

        static void Methode2(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.WriteLine("-");
            }
        }

        static void Methode3(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.WriteLine("*");
            }
        }
    }
}
