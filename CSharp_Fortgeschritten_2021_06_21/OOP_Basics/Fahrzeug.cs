using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace OOP_Basics
{

    #region Motorzied
    public enum MotorizedTyp { Dampf, Diesel, Electro }
    public interface IMotorized
    {
        bool MotorIsRunning { get; set; }
        void StarteMotor();
        void StoppeMotor();

        MotorizedTyp Type { get; set; }
    }
    #endregion


    public interface ICanSwim
    {
        public double Tiefgang { get; set; }
    }

    public abstract class VehicleBase
    {
        private int baujahr;
        private string marke;
        private double aktuelleGeschwindigkeit;
        private double maxGeschwindigkeit;


        public static int AnzahlErstellterFahrzeuge { get; private set; } = 0;
        //ctor + tab + tab -> Konstruktor
        public VehicleBase()
        {
            AnzahlErstellterFahrzeuge++;
        }

        public VehicleBase(int Baujahr, string Marke, double AktuelleGeschwindigkeit, double MaxGeschwindigkeit)
            :this()
        {
            this.baujahr = Baujahr;
            this.marke = Marke;
            this.aktuelleGeschwindigkeit = AktuelleGeschwindigkeit;
            this.maxGeschwindigkeit = MaxGeschwindigkeit;
        }

        #region Properties
        public int Baujahr { get => baujahr; set => baujahr = value; }
        public string Marke 
        { 
            get => marke;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                marke = value;
            }
        }
        public double AktuelleGeschwindigkeit { get => aktuelleGeschwindigkeit; set => aktuelleGeschwindigkeit = value; }
        public double MaxGeschwindigkeit { get => maxGeschwindigkeit; set => maxGeschwindigkeit = value; }
        
        #endregion

        //Diese Methode kann Beschleunigen 
        //Für motorisierte Fortbewegungsmittel werden wir diese Methode überschreiben.
        public virtual void Beschleunigung (int a) //base.Beschleunigung
        {
            if (this.AktuelleGeschwindigkeit + a > this.MaxGeschwindigkeit)
            {
                this.AktuelleGeschwindigkeit = this.MaxGeschwindigkeit;
            }
            else if (this.AktuelleGeschwindigkeit + a < 0)
                this.AktuelleGeschwindigkeit = 0;
            else
                this.AktuelleGeschwindigkeit += a;
        }

        public abstract void Repair();

        public static double MphTOKmh(double mph)
        {
            return mph * 1.60934;
        }

        public static double KmhTOMph(double kmph)
        {
            return 0.6214 * kmph;
        }
    }

    public class ShipBase : VehicleBase, ICanSwim
    {
        private double _tiefgang;

        public ShipBase(int Tiefgang, int Baujahr, string Marke, double AktuelleGeschwindigkeit, double MaxGeschwindigkeit) 
            : base(Baujahr, Marke, AktuelleGeschwindigkeit, MaxGeschwindigkeit)
        {
            this.Tiefgang = Tiefgang;
        }

        public double Tiefgang 
        { 
            get
            {
                return _tiefgang;
            }
            set
            {
                _tiefgang = value;
            } 
        }
        

        

        public override void Repair()
        {
            Console.WriteLine("Schiff geht an die Docks");
        }


    }


    public class SchiffWithEngine : ShipBase, IMotorized
    {
        public bool MotorIsRunning { get; set; }
        public MotorizedTyp Type { get; set; }


        public SchiffWithEngine(int Tiefgang, int Baujahr, string Marke, double AktuelleGeschwindigkeit, double MaxGeschwindigkeit, bool MotorIsRunning = false, MotorizedTyp motorTyp=MotorizedTyp.Dampf)
            :base(Tiefgang, Baujahr, Marke, AktuelleGeschwindigkeit, MaxGeschwindigkeit)
        {
            this.MotorIsRunning = MotorIsRunning;
            this.Type = motorTyp;
        }

        public void StarteMotor()
        {
            MotorIsRunning = true;
        }

        public void StoppeMotor()
        {
            MotorIsRunning = false;
        }

        public override void Beschleunigung(int a)
        {
            
            if (MotorIsRunning)
                base.Beschleunigung(a);
        }
    }

    //public class Segelschiff : ShipBase
    //{
    //    public int AnzahlMasten { get; set; }
    //    public bool IsSegelAvailable { get; set; }

    //    public override void Beschleunigung(int a)
    //    {
    //        if (AnzahlMasten > 0 && IsSegelAvailable)
    //            base.Beschleunigung(a);
    //    }
    //}

    public class Flugzeug : VehicleBase
    {
        private double spannweite;
        private double maxFlughoehe;

        public double Spannweite { get => spannweite; set => spannweite = value; }
        public double MaxFlughoehe { get => maxFlughoehe; set => maxFlughoehe = value; }

        public override void Repair()
        {
            Console.WriteLine("Flugzeug steht nun im Hangar");
        }
    }


    
}
