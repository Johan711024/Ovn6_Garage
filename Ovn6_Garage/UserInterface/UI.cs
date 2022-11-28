using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.UserInterface
{
    internal class UI : IUI
    {
        public string GetInput()
        {
            return Console.ReadLine()!;
        
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
           
        }
        public void Clear()
        {
            Console.Clear();
            

        }
    }
}
