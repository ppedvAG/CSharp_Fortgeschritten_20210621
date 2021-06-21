using System;

namespace CSharp72
{
    class Program
    {
        static void Main(string[] args)
        {

            PersonStruct p1 = new PersonStruct() { Vorname = "Max", Nachname = "Muster" };

            PersonStruct p2 = new PersonStruct() { Vorname = "Heike", Nachname = "Musterfrau" };

            ref PersonStruct referenz = ref p1;
            Console.WriteLine($"{referenz.Vorname} {referenz.Nachname}");
            
            referenz = ref p2;
            Console.WriteLine($"{referenz.Vorname} {referenz.Nachname}");



            int z1_param = 10;
            int z2_param = 15;
            int z3_param = 25;

            Summe(z1_param, z2_param, z3_param); //10 + 15 + 25
            Summe(z1_param, z2_param);  //10 + 15 + 0
            Summe(z1_param); //10 + 0 + 0


            PersonStruct person1 = new PersonStruct();
            person1.Vorname = "Max";
            person1.Nachname = "Mustermann";

            PersonStruct person2 = person1; //kopiert er jede Variable und Property jeweils 


        }
        public static long Summe (int z1, int z2 = default, int z3 = default)
        {
            return z1 + z2 + z3;
        }

    }

    public struct PersonStruct
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
