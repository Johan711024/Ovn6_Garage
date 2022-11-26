using Ovn6_Garage.UserInterface;
using Ovn6_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Manager
    {
        private Handler handler = null!;
        private Garage<Vehicle> garage = null!;
        private IUI ui = null!;


        internal void Run(IUI ui)
        {
            this.ui = ui;
            ui.Print($"Running...");

            int ParkingSpotsInGarage = 5;
            
            Initialize(ParkingSpotsInGarage);
            Start();

        }

        public void Start()
        {
            ui.Print($"VÄLKOMMEN TILL GARAGET");
            ui.Print($"I detta garage finns det {garage.MaximumSpots} platser\n\n");
            ui.Print($"Kör in fordon? \t(In)");
            ui.Print($"Kör ut fordon? \t(Ut)");
            ui.Print($"Avsluta dagen? \t\t(Q)\n\n");


            bool quit = false;

            do
            {
                ui.Print($"Lediga platser just nu {handler.AvailableSpots}");
                string input = ui.GetInput()!;

                switch (input)
                {
                    case "In":
                        handler.In();                       
                        break;
                    case "Ut":
                        handler.Out();
                        break;
                    case "q":
                        quit= true;
                        break;
                    case "Q":
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);


        }

        private void Initialize(int maxParkingSpots)
        {
            //skapar garaget med begränsat antal platser och några parkerade fordon
            garage = new Garage<Vehicle>(maxParkingSpots);
            
            garage.ParkingSpots.Add(new Car(4, "red", "REG123", 5));
            garage.ParkingSpots.Add(new Motorbike(2, "black", "XXX111", 2));
            garage.ParkingSpots.Add(new Aeroplane(4, "white", "YYY222", 10.5));

            

            //skapar handler och låter handler få kontroll över garaget
            handler = new Handler(garage, maxParkingSpots);
        }
        
    }
}
