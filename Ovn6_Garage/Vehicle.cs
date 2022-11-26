using System.Drawing;

namespace Ovn6_Garage
{
    public abstract class Vehicle
    {
        
        public Vehicle(int wheels, string paint, string regNr)
        {
            
            Wheels = wheels;
            Paint = paint;
            RegNr = regNr;
            
        }
        public int Wheels { get; set; }
        public string Paint { get; set; } = string.Empty;
        public string RegNr { get; set; } = string.Empty;

        public abstract string DoSound();

        public virtual string Info()
        {
            
            return $"Wheels: {Wheels}, Paint: {Paint}, Number plate: {RegNr}, ";
        }



    }
}