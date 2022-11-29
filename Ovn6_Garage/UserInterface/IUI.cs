using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage.UserInterface
{
    public interface IUI
    {
        public string GetInput();
        public void Print(string message);
        public void Clear();
    }
}
