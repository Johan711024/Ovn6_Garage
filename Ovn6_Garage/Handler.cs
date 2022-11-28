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
    class Handler
    {
        private Garage<Vehicle> garage;
        //public int AvailableLots { get; internal set; }
        public int MaximumSpots { get; internal set; }
        private IUI ui = null!;
        private int parkingLotsInGarage;

        public int AvailableLots => MaximumSpots - garage.OccupiedLots;//ToDo: Fungerar troligen inte pga .length inte visar upptagna platser



        public Handler(Garage<Vehicle> garage, int max, IUI ui)
        {
            this.garage = garage;
            this.ui = ui;

            MaximumSpots = max;
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

            return new Car(Int32.Parse(hjul),colour, regnr, Int32.Parse(seats));
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
        

        internal void All()
        {
            if (garage.IsEmpty) {  ui.Print("Finns inga fordon i garaget"); return; }


            

                for (var i = 0; i < garage.parkingLots.Length; i++)
                {
                    if (garage.parkingLots[i] != null) { ui.Print(garage.parkingLots[i].Info()); }  //hur skriva turner operator?
                }
            


        }

        internal void Search()
        {
            ui.Print("Sök via RegNr");
            string input = ui.GetInput();
            bool searchHit = false;

            for (var i = 0; i < garage.parkingLots.Length; i++)
            {
                if (garage.parkingLots[i] != null)
                {
                    if (garage.parkingLots[i].RegNr == input)
                    {
                        ui.Print(garage.parkingLots[i].Info());
                        searchHit = true;
                        break;
                    }
                }
            }
            if (!searchHit) ui.Print("Hittade inget");



        }
        internal void SearchAdvanced(string regnr = "", string type = "", string color = "")
        {
            ui.Print("Sök fordonstyp t ex boat, car, aeroplane, motorbike");
            string input = ui.GetInput();
            int hits=0;
            
            for (var i = 0; i < garage.parkingLots.Length; i++)
            {
                if (garage.parkingLots[i] != null)
                {
                    if (garage.parkingLots[i].GetType().Name.ToLower() == input.ToLower())
                    {
                        hits++;
                    }
                }
            }

            //Nedanstående ger null problem
            //var hits = garage.parkingLots.Where(x => x.GetType().Name == input).Select(item => item.Paint);

            

            if (hits > 0) { ui.Print($"hittade {hits}st {input}"); }else { ui.Print("Hittade inget"); };        
        
        }
    }
}
