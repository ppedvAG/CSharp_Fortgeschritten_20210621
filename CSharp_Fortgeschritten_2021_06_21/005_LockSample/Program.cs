using System;
using System.Threading;

namespace _005_LockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(MachEinKontoUpdate);
            }

            Console.WriteLine("fertig)");
            Console.ReadKey();
        }

        private static void MachEinKontoUpdate(object state)
        {
            Random r = new Random();
            Konto meinKonto = new Konto();


            for (int i = 0; i < 50; i++)
            {
                int auswahl = r.Next(0, 10);

                if (auswahl % 2 == 0)
                {
                    meinKonto.Einzahlen(r.Next(0, 1000));
                }
                else
                    meinKonto.Abheben(r.Next(0, 1000));


                Console.WriteLine(meinKonto.Kontostand);
            }
        }
    }
}
