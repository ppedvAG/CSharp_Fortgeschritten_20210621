using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    class Program
    {
        static void Main(string[] args)
        {
            GebeZahlenAus();
            Console.ReadLine();


        }

        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i <20; i++)
            {
                await Task.Delay(100);
                yield return i; //Hier gebe ich nur ein Ergebnis zurück (stream) 
            }
        } //Hier werde ich meine Methode verlassen

        public static async void GebeZahlenAus()
        {
            await foreach (var zahl in GeneriereZahlen())
            {
                Console.WriteLine(zahl); // 0 -> 19 werden hier ausgegeben
            }
        }
    }
}
