using System;
using System.Threading.Tasks;

namespace _001_EasyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Threading.Tasks
            Task easyTask = new Task(MachEtwas); // Funktionszeiger wird übergeben
            easyTask.Start();
            easyTask.Wait(); //Warte auf Task

            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }

            Console.ReadKey();
        }


        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("#");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
