using System.Collections;
using System.Collections.Generic;

namespace Ovn6_Garage
{
    public class LimitedList<T> : ILimitedList<T> where T : Vehicle
    {

        private readonly int capacity;
        private T[] list;

        public int Count => list.Count();

        public bool IsFull => capacity <= Count;

        public T this[int index] => throw new NotImplementedException();

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2); //returnerar största talet
            list = new T[this.capacity];
        }

        public virtual bool Add(T newVehicle)
        {
            ArgumentNullException.ThrowIfNull(newVehicle, nameof(newVehicle));

            if (IsFull) return false;

            for (var i = 0; i < list.Length; i++)
            {
                if (list[i] is null)
                {
                    list[i] = newVehicle;
                    return true;
                }
            }

            return false;

        }

        //public void Print(Action<T> action)
        //{
        //    list.ForEach(i => action?.Invoke(i));  //Overloads: Executes the specified delegate on the thread that owns the control's underlying window handle. Action is a delegate that contains a method to be called in the control's thread context.
        //}

        public bool Remove(T item)
        {

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                //....... 

                yield return item; //Yield: Creates an awaitable object that asynchronously yields control back to the current dispatcher and provides an opportunity for the dispatcher to process other events.
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    
}

}