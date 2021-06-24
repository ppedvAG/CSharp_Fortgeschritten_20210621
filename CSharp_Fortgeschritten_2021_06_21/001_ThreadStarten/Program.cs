using System;
using System.Threading;

namespace _001_ThreadStarten
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread liegt in System.Threading;
            Thread thread = new Thread(MacheEtwasInEinemThread); //Übergeben den Funktionszeige von MacheEtwasInEinemThread
            thread.Start(300); //MacheEtwasInEinemThread wird im Thread ausgeführt

            thread.Join(); //Warten wir, bis Thread fertig ist
            
            for (int i = 0; i < 100; i++)
                Console.Write("+");


            Console.ReadLine();
        }



        private static void MacheEtwasInEinemThread(object obj) //<- Funktionszeiger 
        {
            for (int i = 0; i < (int)obj; i++)
                Console.Write("#");
        }
    }

    
}
