using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Handler
    {
        private Garage<Vehicle> garage;
        public int AvailableSpots { get; internal set; }
        public int MaximumSpots { get; internal set; }

        public Handler(Garage<Vehicle> garage, int max)
        {
            this.garage = garage;

            MaximumSpots = max;
            //AvailableSpots = garage.ParkingSpots.Count()-garage.ParkingSpots;
            AvailableSpots = MaximumSpots - garage.ParkingSpots.Count();
        }

        internal void In()
        {
            if (AvailableSpots >= 0 && AvailableSpots <= MaximumSpots)
            {
                AvailableSpots--;
            }
        }

        internal void Out()
        {
            if (AvailableSpots >= 0 && AvailableSpots <= MaximumSpots)
            {
                AvailableSpots++;
            }
        }
    }
}
