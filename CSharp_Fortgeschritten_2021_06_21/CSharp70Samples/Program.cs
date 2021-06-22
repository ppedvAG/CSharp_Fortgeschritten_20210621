using System;

namespace CSharp70Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Literale
            //Geldbeträge mit decimal Datentyp
            decimal money = 1_000_000m; //m -> gibt an, dass es sich zu eine direkte decimal Zuweisung handelt.
            #endregion



            #region Rückgabe per Referenz
            
            #endregion
        }


        #region Out-Variablen Beispiel
        private static void IntCheck()
        {
            string eingabe = "12345";
            int ausgabe;
   
            if (int.TryParse(eingabe, out ausgabe)) //out hat eine regel -> wenn eine Methode eine out-variable verwendet, muss diese einen Wert zugewiesen bekommen, 
            {
                //Im Erfolgsfall kommen wir hier her 
                Console.WriteLine(ausgabe);
            }
        }

        //B- Variante

        private static void IntCheck_VarianteB()
        {
            string eingabe = "12345";
            

            if (int.TryParse(eingabe,  out var ausgabe))
            {
                Console.WriteLine(ausgabe);
            }
        }

        #endregion




        #region Pattern Matching
        private void SchreibSterneInKonsole(object o)
        {
            if (o is null)
            {
                return;
            }

            //Prüfe ob o ein Integer-Wert ist.
            // Wenn ja wird der Wert von Variable o nach i gesetzt. 
            if (o is int i)
            {
                return;
            }
        }
        #endregion

        private void PAtternMatchingMitSwitchSample(Grafik g)
        {
            switch (g)
            {
                case Kreis k:
                    Console.WriteLine($"Kreis mit dem Radius {k.Name}");
                        break;
                case Rechteck r:
                    Console.WriteLine($"Rechteck {r.Breite}");
                    break;
                default:
                    Console.WriteLine($"Unbekanntest Objekt ;");
                    break;
            }
        }

        public ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i =0; i<  zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                {
                    return ref zahlen[i];
                }
            }
            throw new IndexOutOfRangeException();
        }

    }




    public class Grafik
    {
        public int HexColor { get; set; }
        public string Name { get; set; }
    }

    public class Kreis : Grafik 
    {
        public double Radius { get; set; }
    }

    public class Rechteck :Grafik
    {
        public double Breite { get; set; }
        public double Laenge { get; set; }
    }




}
