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
        private Garage garage = null!;


        internal void Start()
        {
            Console.WriteLine($"Starting up manageing-the-garage procedures");

            Initialize();

        }

        private void Initialize()
        {
            Console.WriteLine($"Initializing");
            garage = new Garage(10);
            handler = new Handler(garage);
        }
    }
}
