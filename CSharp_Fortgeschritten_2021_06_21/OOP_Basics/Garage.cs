using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Basics
{
    public class Garage
    {
        public IList<VehicleBase> garageItems = new List<VehicleBase>();

        public Garage()
        {

        }

        public void Insert(VehicleBase Vehicle)
        {
            if (VehicleBase.AnzahlErstellterFahrzeuge < 10)
            {
                garageItems.Add(Vehicle);
            }
        }
    }
}
