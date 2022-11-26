using LimitedList;
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

        [MaybeNull]
        public List<Vehicle> Vehicles { get; set; } 



        public Garage(int pSpots)
        {
            
            ParkingSpots = new LimitedList<Vehicle>(pSpots);

            MaximumSpots = pSpots;

            //Vehicles = new List<Vehicle>();   //ToDo: Här ska listan istället göras till en Array med begränsade platser dvs antalet sätts till Parkingspots

            
            
        }




    }
}
