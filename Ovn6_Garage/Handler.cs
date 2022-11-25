using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Handler
    {
        private Garage garage;
        public int AvailableSlots { get; internal set; }

        public Handler(Garage garage)
        {
            this.garage = garage;
            AvailableSlots = garage.ParkingSlots;
        }

        internal void In()
        {
            if (AvailableSlots >= 0 && AvailableSlots <= garage.ParkingSlots)
            {
                AvailableSlots--;
            }
        }

        internal void Out()
        {
            if (AvailableSlots >= 0 && AvailableSlots <= garage.ParkingSlots)
            {
                AvailableSlots++;
            }
        }
    }
}
