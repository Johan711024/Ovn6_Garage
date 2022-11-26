using Ovn6_Garage.UserInterface;
using Ovn6_Garage.Vehicles;
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
        private IUI ui = null!;

        public Handler(Garage<Vehicle> garage, int max, IUI ui)
        {
            this.garage = garage;
            this.ui = ui;

            MaximumSpots = max;
            //AvailableSpots = garage.ParkingSpots.Count()-garage.ParkingSpots;
            AvailableSpots = MaximumSpots - garage.ParkingSpots.Count();
        }

        internal void In()
        {
            
            Vehicle? newVehicle = pickNewVehicle();  //Todo: hantera null

            if (newVehicle != null)
            {
                garage.ParkingSpots.Add(newVehicle);    
            }
            else
            {
                ui.Print("Felaktig inmatning. Försök igen!");
            }
            
            
            if (AvailableSpots >= 0 && AvailableSpots <= MaximumSpots)
            {
                AvailableSpots--;
            }
        }

        private Vehicle pickNewVehicle()
        {
            ui.Print($"Vilken typ av fordon? Skriv bil, motorcykel, båt eller flygplan");
            string input = ui.GetInput();

            switch (input)
            {
                case "bil":
                    return getCar();
                case "motorcykel":
                    return getCar();
                case "båt":
                    return getCar();
                case "flygplan":
                    return getCar();

                default:
                    return null!;
                   
            } 
        }

        private Vehicle getCar()
        {
            return new Car(4,"grey", "NEW000",2);
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
