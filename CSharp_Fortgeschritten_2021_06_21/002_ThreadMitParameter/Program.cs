using System;
using System.Threading;

namespace _002_ThreadMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Threading;
            ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MacheEtwasInEinemThread);
            Thread thread = new Thread(parameterizedThread);

            thread.Start(123);
            thread.Join();

            for (int i = 0; i < 100; i++)
                Console.Write("+");


            Console.ReadLine();
        }


        private static void MacheEtwasInEinemThread(object obj) //<- Funktionszeiger 
        { 
            if (obj is int until)
            {
                for (int i = 0; i < until; i++)
                    Console.Write("#");
            }
        }
    }
}
