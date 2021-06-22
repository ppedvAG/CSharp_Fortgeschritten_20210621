using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    class Program
    {
        private static string[] myArray = new string[10];

        static void Main(string[] args)
        {
            myArray[0] = "Hallo";
            myArray[1] = "liebe";
            myArray[2] = "Teilnehmer";
            myArray[3] = "Heute";
            myArray[4] = "ist";
            myArray[5] = "guter";
            myArray[6] = "Tag";


            int startindex = 3;
            int endindex = 5;

            var text = myArray[startindex..];
            var text1 = myArray[..endindex];

            GebeZahlenAus();
            Console.ReadLine();

            //Verbatim String
            Console.WriteLine("Ausgabe irgendwas" + myArray[0] + " weiterer Text " + myArray[1]); //böser String
            Console.WriteLine("Ausgabe irgendwas {0} weiterer Text {1}", myArray[0], myArray[1]); //kommt aus C++ -> printf 
            Console.WriteLine($"Ausgaben irgendwas {myArray[0]} weiterer Text {myArray[0]}");

            string dateiPfad = "C:\\Temp\\ABC"; //Warum 2

            string einfacherFormatierterText = "Ich bin ein String \n und hier ist eben ein Zeilenumbruch passiert \t neuer Tabularor"; //Escape-Zeichen 

            string dateiPfad2 = @"C:\Windows\Temp sdfkjnsdfkjgnskdfgjn";
        }

        //public static async IAsyncEnumerable<int> GeneriereZahlen(int hallo)
        //{
        //    for (int i = 0; i <20; i++)
        //    {
        //        await Task.Delay(100);
        //        yield return i; //Hier gebe ich nur ein Ergebnis zurück (stream) 
        //    }
        //} //Hier werde ich meine Methode verlassen

        //public static async void GebeZahlenAus()
        //{
        //    await foreach (var zahl in GeneriereZahlen())
        //    {
        //        Console.WriteLine(zahl); // 0 -> 19 werden hier ausgegeben
        //    }
        //}
    }
}
