using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(MachEtwas);
            t.Start();

            Thread.Sleep(3000);
            //t.Abort(); //Abort is obselete

            t.Interrupt();
        }



        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("zZzZZ");
                }
            }
            catch
            {

            }

        }
    }
}
