using System;
using System.Collections.Generic;
using System.Linq;
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

    public class VehicleBase
    {
        private int baujahr;
        private string marke;
        private double aktuelleGeschwindigkeit;
        private double maxGeschwindigkeit;
        
        //ctor + tab + tab -> Konstruktor
        public VehicleBase()
        {
           
        }

        public VehicleBase(int Baujahr, string Marke, double AktuelleGeschwindigkeit, double MaxGeschwindigkeit, bool MotorIsRunning=false)
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
        public virtual void Beschleunigung (int a)
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
    }

    public class ShipBase : VehicleBase, ICanSwim
    {
        public double Tiefgang { get; set; }
    }


    public class SchiffWithEngine : ShipBase, IMotorized
    {
        public bool MotorIsRunning { get; set; }
        public MotorizedTyp Type { get; set; }

        public void StarteMotor()
        {
            MotorIsRunning = true;
        }

        public void StoppeMotor()
        {
            MotorIsRunning = false;
        }
    }




     

    public class Flugzeug : VehicleBase
    {
        private double spannweite;
        private double maxFlughoehe;


        public double Spannweite { get => spannweite; set => spannweite = value; }
        public double MaxFlughoehe { get => maxFlughoehe; set => maxFlughoehe = value; }
    }


    
}
