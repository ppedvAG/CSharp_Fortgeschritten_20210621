using System;
using System.Collections.Generic;
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

                }
            }

        }
    }
}
