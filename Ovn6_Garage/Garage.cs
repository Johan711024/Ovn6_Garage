using LimitedList;
using Ovn6_Garage.UserInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    public class Garage<T> where T : Vehicle
    {
        
        private readonly int capacity;
        public T[] parkingLots;

        public int OccupiedLots => parkingLots.Length-AvailableLots();
        public bool IsFull => capacity <= OccupiedLots;

        //public T this[int index] => throw new NotImplementedException();

        public int AvailableLots()
        {
            int available=0;
            for(var i=0; i < capacity; i++)
            {
                if (parkingLots[i] == null) available++;
            }
            return available;
        }

        public Garage(int maximumParkingLots)
        {

            this.capacity = Math.Max(maximumParkingLots, 1); //Returnerar största talet. Ett garage måste ha 1 eller fler platser
            parkingLots = new T[this.capacity];

        }
        public virtual bool Add(T newVehicle)
        {
            ArgumentNullException.ThrowIfNull(newVehicle, nameof(newVehicle));

            if (IsFull) return false;

            for (var i = 0; i < parkingLots.Length; i++)
            {
                if (parkingLots[i] is null)
                {
                    parkingLots[i] = newVehicle;
                    return true;
                }
            }
            return false;
        }
        public bool Remove(string removeRegNr)
        {
            for(var i = 0; i<parkingLots.Length; i++)
            {
                if (removeRegNr == parkingLots[i].RegNr)
                {
                    parkingLots[i] = null!;
                    return true;
                }
            }
            
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var parkingLot in parkingLots)
            {
                //....... 

                yield return parkingLot; //Yield: Creates an awaitable object that asynchronously yields control back to the current dispatcher and provides an opportunity for the dispatcher to process other events.
            }
        }

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
