using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_TaskContinueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                //anonyme Methode 
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(800);
                //throw new Exception();
            });

            t1.Start();
            //Allgemeiner Nachfolger-Task
            t1.ContinueWith(t => { Console.WriteLine("T1 Continue"); });
            t1.ContinueWith(t => { Console.WriteLine("T1 ist ok"); }, TaskContinuationOptions.OnlyOnRanToCompletion); //Führe diesen Task aus, wenn der erste Task (t1) fehlerfrei abgelaufen ist
            t1.ContinueWith(t => { Console.WriteLine("T1 hat ein Fehler"); }, TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadLine();
        }
    }
}
