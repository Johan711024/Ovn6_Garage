using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.Vehicles
{
    internal class Aeroplane : Vehicle
    {
        public Aeroplane(int wheels, string paint, string regNr, double length) : base(wheels, paint, regNr)
        {
            Lenght = length;
        }

        public object Lenght { get; }

        public override string DoSound()
        {
            return "swish";
        }
    }
}
