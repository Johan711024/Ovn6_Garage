using Ovn6_Garage.UserInterface;
using Ovn6_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    public class Handler : IHandler
    {
        private IUI ui;
        private Garage<Vehicle> garage;
        //public int AvailableLots { get; internal set; }
        public int MaximumSpots => garage.Capacity;

        public int AvailableLots => MaximumSpots - garage.OccupiedLots;//ToDo: Fungerar troligen inte pga .length inte visar upptagna platser

        public Handler(int max, IUI ui)
        {
            this.ui = ui;
            garage = new Garage<Vehicle>(max, ui);

          //MaximumSpots = max;
            //AvailableSpots = garage.ParkingSpots.Count()-garage.ParkingSpots;

        }

        internal void In()
        {
            Vehicle? newVehicle = pickNewVehicle();

            if (newVehicle != null)
            {
                garage.Add(newVehicle);
            }
            else
            {
                ui.Print("Felaktig inmatning. Försök igen!");
            }
            //AvailableSpots = MaximumSpots - garage.ParkingSpots.Count();      
        }

        internal void Out()
        {
            All();

            ui.Print("\n\nEn ska bort. Skriv RegNr");
            string removeRegNr = ui.GetInput();

            garage.Remove(removeRegNr);
        }

        private Vehicle pickNewVehicle()
        {
            ui.Print($"Vilken typ av fordon? Skriv bil, motorcykel, båt eller flygplan");
            string input = ui.GetInput();

            switch (input)
            {
                case "bil":
                    return createCar();
                case "motorcykel":
                    return createMotorbike();
                case "båt":
                    return createBoat();
                case "flygplan":
                    return createAeroplane();

                default:
                    return null!;

            }
        }


        internal void All()
        {
            if (garage.IsEmpty) { ui.Print("Finns inga fordon i garaget"); return; }

            foreach (var vehicle in garage)
            {
                ui.Print(vehicle.Info());
            }

        }
        public void searchNoPlate()
        {
            ui.Print("Sök via RegNr");
            string input = ui.GetInput();

            int hits = garage.Where(vehicle => vehicle.RegNr == input).Count();

            if (hits > 0) { ui.Print($"hittade {hits}st {input}"); } else { ui.Print("Hittade inget"); };

        }

        // Till lärare: Har ok koll på LINQ, arrow functions, koda menyer o sökningar. Vill lägga tid på annat som är svårare att lösa.
        internal void SearchAdvanced(string regnr = "", string type = "", string color = "")
        {
            ui.Print("Sök fordonstyp t ex Boat, Car, Aeroplane, Motorbike");
            string input = ui.GetInput();
            int hits = garage.Where(vehicle => vehicle.GetType().Name == input).Count();

            if (hits > 0) { ui.Print($"hittade {hits}st {input}"); } else { ui.Print("Hittade inget"); };

        }





        private Vehicle createCar()
        {
            ui.Print("Antal hjul?");
            string hjul = ui.GetInput();
            ui.Print("Färg?");
            string colour = ui.GetInput();
            ui.Print("RegNr?");
            string regnr = ui.GetInput();
            ui.Print("Antal säten?");
            string seats = ui.GetInput();

            return new Car(Int32.Parse(hjul), colour, regnr, Int32.Parse(seats));
        }
        private Vehicle createMotorbike()
        {
            ui.Print("Antal hjul?");
            string hjul = ui.GetInput();
            ui.Print("Färg?");
            string colour = ui.GetInput();
            ui.Print("RegNr?");
            string regnr = ui.GetInput();
            ui.Print("Antal cylindrar?");
            string seats = ui.GetInput();

            return new Motorbike(Int32.Parse(hjul), colour, regnr, Int32.Parse(seats));
        }
        private Vehicle createBoat()
        {
            ui.Print("Antal hjul?");
            string hjul = ui.GetInput();
            ui.Print("Färg?");
            string colour = ui.GetInput();
            ui.Print("RegNr?");
            string regnr = ui.GetInput();
            ui.Print("Antal motorer?");
            string seats = ui.GetInput();

            return new Boat(Int32.Parse(hjul), colour, regnr, Int32.Parse(seats));
        }
        private Vehicle createAeroplane()
        {
            ui.Print("Antal hjul?");
            string hjul = ui.GetInput();
            ui.Print("Färg?");
            string colour = ui.GetInput();
            ui.Print("RegNr?");
            string regnr = ui.GetInput();
            ui.Print("Längd?");
            string seats = ui.GetInput();

            return new Aeroplane(Int32.Parse(hjul), colour, regnr, Convert.ToDouble(seats));
        }

        internal void Seed()
        {
            garage.Add(new Car(4, "red", "aaa111", 5));
            garage.Add(new Motorbike(2, "black", "bbb222", 2));
            garage.Add(new Aeroplane(4, "white", "ccc333", 10.5));
        }
    }
}
