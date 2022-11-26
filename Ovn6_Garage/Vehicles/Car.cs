using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public int NoOfSeats { get; }

        public Car(int wheels, string paint, string regNr, int noOfSeats) : base(wheels, paint, regNr)
        {
            NoOfSeats = noOfSeats;
        }

        

        public override string DoSound()
        {
            return "brum";
        }
    }
}
