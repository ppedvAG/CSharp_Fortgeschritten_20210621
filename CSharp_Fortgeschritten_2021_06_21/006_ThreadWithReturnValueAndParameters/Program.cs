using System;
using System.Threading;

namespace _006_ThreadWithReturnValueAndParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            string retStr = string.Empty;

            Thread thread = new Thread(() =>
            {
                retStr = StringToUpper("Hello World");
            });

            thread.Start();
            thread.Join();

            Console.WriteLine(retStr);
            Console.ReadLine();


        }



        public static string StringToUpper(string param1)
        {
            return param1.ToUpper();
        }
    }
}
