using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_TaskBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = Task.Factory.StartNew(MeineMethodeMitAbbrechen, cts);

            cts.Cancel();
        }

        private static void MeineMethodeMitAbbrechen(object param) //param -> cts objekt
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while (true)
            {
                Console.WriteLine("zzz...zzzz....zzzz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;
            }
        }
    }
}
