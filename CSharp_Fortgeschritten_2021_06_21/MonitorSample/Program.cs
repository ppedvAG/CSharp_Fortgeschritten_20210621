using System;
using System.Threading;

namespace MonitorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static void KritischerCodeAbschnitt()
        {
            int x = 1;
            Monitor.Enter(x); //Codeabschnitt wird vom ersten Thread gesperrt

            try
            {
                //Mach was
            }
            finally
            {
                Monitor.Exit(x);
            }
        }
    }
}
