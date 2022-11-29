using Ovn6_Garage.UserInterface;
using Ovn6_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    internal class Manager
    {
        private Handler handler = null!;
        private Garage<Vehicle> garage = null!;
        private IUI ui = null!;
        private int parkingLotsInGarage;


        internal void Run(IUI ui, int maxParkingLots=5)
        {
            this.ui = ui;
            ui.Print($"Running...");

            parkingLotsInGarage = maxParkingLots;
            
            Initialize();
            Start();
        }

        public void Start()
        {
            bool quit = false;
            string input = "";

            do
            {
                ui.Clear();
                ui.Print($"VÄLKOMMEN TILL GARAGET");
                ui.Print($"I detta garage finns det {parkingLotsInGarage} platser.");
                ui.Print($"\n\nLediga platser just nu {handler.AvailableLots}\n\n");

                switch (input.ToLower())
                {
                    case "in":
                        handler.In();                       
                        break;
                    case "ut":
                        handler.Out();
                        break;
                    case "alla":
                        handler.All();
                        break;
                    case "sök":
                        handler.searchNoPlate();
                        break;
                    case "av":
                        handler.SearchAdvanced();
                        break;
                    case "q":
                        quit= true;
                        break;                  
                    case "":
                        MainMenu();
                        break;
                    default:
                        MainMenu();
                        break;
                }
                input = ui.GetInput()!;

            } while (!quit);


        }

        private void MainMenu()
        {
            ui.Print($"(In)\tParkera fordon? \t");
            ui.Print($"(Ut)\tKör ut fordon? \t");
            ui.Print($"(Alla)\tSe alla parkerade? ");
            ui.Print($"(Sök)\tSök efter fordon? ");
            ui.Print($"(Av)\tAvancerad sök? \n");
            ui.Print($"(Q)\tAvsluta dagen? \t\t\n\n");
            
        }

        private void Initialize()
        {
            //skapar garaget med begränsat antal platser och några parkerade fordon
            garage = new Garage<Vehicle>(parkingLotsInGarage, ui);

            seed(garage);
            

            //skapar handler och låter handler få kontroll över garaget
            handler = new Handler(garage, parkingLotsInGarage, ui);
        }

        private void seed(Garage<Vehicle> garage)
        {
            
            garage.Add(new Car(4, "red", "aaa111", 5));
            garage.Add(new Motorbike(2, "black", "bbb222", 2));
            garage.Add(new Aeroplane(4, "white", "ccc333", 10.5));
            
        }
        
    }
}
