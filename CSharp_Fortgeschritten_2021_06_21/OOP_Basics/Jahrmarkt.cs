using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Basics
{
    public interface IFSK
    {
        int AbAlter { get; }
    }

    
    public class Standplatz
    {
        public int Quatratmeter { get; set; }
        public decimal Miete { get; set; }
    }

    public class Rollercoster : Standplatz, IFSK
    {
        public int Streckenlaenge { get; set; }
        public int Hoehe { get; set; }

        public int AbAlter
        {
            get
            {
                return 18;
            }
        }
    }

    public class Scooter : Standplatz
    {
        public int AnzahlAutos { get; set; }
    }

    public class Gruselkabinett : Standplatz, IFSK
    {
        public int AnzahlArtisten { get; set; }

        public int AbAlter
        {
            get
            {
                return 16;
            }
        }
    }


    public class AClassWithNETCoreInterfaces : IDisposable, IComparable, ICloneable
    {

        private int variableA;
        private int variableB;

        public int VariableA { get => variableA; set => variableA = value; }
        public int VariableB { get => variableB; set => variableB = value; }

        public object Clone()
        {
            AClassWithNETCoreInterfaces copy = new AClassWithNETCoreInterfaces();
            copy.VariableA = this.VariableA;
            copy.variableB = this.VariableB;


            return copy;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //Diese Funktion ermöglicht das aufraumen, bzw abbauen eines Objektes bevor der GC aktiv wird
        }
    }



    public class MyProgramm
    {
        public void Main()
        {
            IList<Standplatz> meinJahrmarkt = new List<Standplatz>();

            meinJahrmarkt.Add(new Gruselkabinett());
            meinJahrmarkt.Add(new Scooter());
            meinJahrmarkt.Add(new Rollercoster());

            foreach (Standplatz currentStandplatz in meinJahrmarkt)
            {
                if (currentStandplatz is Scooter)
                {

                }

                if (currentStandplatz is IFSK)
                {
                    //Alterprüfung machen: Wie alt ist Mustermann und FSK - Voraussetzung abbprüfen 
                }
            }



            FileStream fileStream = null;
            try
            {
                fileStream = File.Create(@"C:\programs\example1.txt");
            }
            catch(Exception ex)
            {

            }
            finally
            {
                fileStream.Close(); //Im Fehler oder Erfolgsfall muss der Handler von der Datei wieder weggenommen werden. 
            }




            using (FileStream fileStream1 = File.Create(@"C:\programs\example1.txt"))
            {
                using (StreamWriter writer = new StreamWriter(fileStream1))
                {
                    writer.WriteLine("Example 1 written");
                }
            }//FileStream Dispose -> FileStream.Close ()
            

        }
    }
}
