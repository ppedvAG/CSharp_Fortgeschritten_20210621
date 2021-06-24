using System;
using System.Threading.Tasks;

namespace _003_TaskWithParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();


            //Normale Task Variante
            Task<string> task1 = new Task<string>(() => MachEtwas(katze, DateTime.Now));
            task1.Wait();
            string result = task1.Result;


            //via Factory
            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            string result1 = task1.Result;

            //Task.Run
            Task<string> task3 = Task.Run<string>(() => MachEtwas(katze));
            task3.Wait();
            string result2 = task3.Result;



        }


        private static string MachEtwas(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return DateTime.Now.ToLongDateString();
        }


        private static string MachEtwas(object input, DateTime date)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            return DateTime.Now.ToLongDateString();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
