using System;

namespace Dependency_Inversion
{
    

    #region Bad Code
    public class BadCar //Porgrammierer A -> 5 Tage
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }

        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }

    public class BadElectroCar : BadCar
    { 
        //Spezielisierung implementieren
    }

    public class BadCarService //Programmierer B ->  3 Tage
    {
        public void RepairCar(BadCar car) //das ist eine harte verdrahtung und das ist nicht gut!
        {
            //reparieren ein Auto
        }
    }
    #endregion


    #region Good Sample
    public interface ICar
    {
         int Id { get; set; }
         string Brand { get; set; }
         string Type { get; set; }

         DateTime ConstructionDate { get; set; }
         int PS { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }

    public class Car: ICar // Programmer A -> 5 Tage arbeit
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }

    public class ElektroCar : Car
    {
        public int BatterieLaufzeit { get; set; }
    }

    public class CarService : ICarService //  Programmer B -> 3 Tage 
    {
        public CarService()
        {
        }

        public CarService(ICarService otherCarService)
        {
           
        }
        public void RepairCar(ICar car)
        {
            //Repariere
        }
    }


    //ICar kann auch Dummy-Objekte untestützen. 
    public class MockCar : ICar//  Programmer B -> 2 Stunden  
    {
        public int Id { get; set; } = 1;
        public string Brand { get; set; } = "VW";
        public string Type { get; set; } = "Polo";
        public DateTime ConstructionDate { get; set; } = DateTime.Now;
        public int PS { get; set; } = 40;
    }


    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();
            carService.RepairCar(new Car());
            carService.RepairCar(new ElektroCar());

            //Andere Car-Hierarchy ->MockObjekte
            carService.RepairCar(new MockCar());
        }
    }
}
