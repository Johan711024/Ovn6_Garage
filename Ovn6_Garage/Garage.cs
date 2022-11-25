using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Garage
    {
        public int ParkingSlots { get; internal set; } = 0;
        

        public Garage(int pSlots)
        {
            ParkingSlots = pSlots;
            
        }




    }
}
