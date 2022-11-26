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
            
            Initialize();
            Start();

        }

        public void Start()
        {
            ui.Print($"VÄLKOMMEN TILL GARAGET");
            ui.Print($"I detta garage finns det {garage.ParkingSpots.Count} platser\n\n");
            ui.Print($"Vill du köra in fordon? \t(In)");
            ui.Print($"Vill du köra ut fordon? \t(Ut)");
            ui.Print($"Vill du avsluta dagen? \t\t(Q)\n\n");


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

        private void Initialize()
        {
            
            garage = new Garage<Vehicle>(5);
            garage.Vehicles.Add(new Car(4, "red", "REG123", 5));
            garage.Vehicles.Add(new Motorbike(2, "black", "XXX111", 2));
            garage.Vehicles.Add(new Aeroplane(4, "white", "YYY222", 10.5));
            handler = new Handler(garage);
        }
        
    }
}
