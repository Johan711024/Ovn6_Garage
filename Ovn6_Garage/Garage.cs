using LimitedList;
using Ovn6_Garage.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Garage<T> where T : Vehicle
    {
        

        public LimitedList<Vehicle> ParkingSpots { get; internal set; }
        public int MaximumSpots { get; set; }

        
        public Garage(int pSpots)
        {
            
            ParkingSpots = new LimitedList<Vehicle>(pSpots);

            MaximumSpots = pSpots;
          
        }

        
    }
}
