using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.Vehicles
{
    internal class Motorbike : Vehicle
    {
        public int CylinderVolume { get; }

        public Motorbike(int wheels, string paint, string regNr, int cylinderVolume) : base(wheels, paint, regNr)
        {
            CylinderVolume = cylinderVolume;
        }

        

        public override string DoSound()
        {
            return "vroom";
        }
    }
}
