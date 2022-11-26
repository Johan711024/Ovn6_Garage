using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int NoOfEngines { get; }

        public Boat(int wheels, string paint, string regNr, int noOfEngines) : base(wheels, paint, regNr)
        {
            NoOfEngines = noOfEngines;
        }

        

        public override string DoSound()
        {
            return "tuut";
        }
    }
}
