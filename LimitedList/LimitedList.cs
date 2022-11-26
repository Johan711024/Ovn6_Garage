using System.Collections;
using System.Collections.Generic;

namespace LimitedList
{
    public class LimitedList<T>:ILimitedList<T> 
    {
        
        private readonly int capacity;
        protected List<T> list;

        public int Count => list.Count;

        public bool IsFull => capacity <= Count;

        public T this[int index] => throw new NotImplementedException();

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2); //returnerar största talet
            list = new List<T>(this.capacity);
        }
        public virtual bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (IsFull) return false;
            list.Add(item); return true;
        }

        public void Print(Action<T> action)
        {
            list.ForEach(i => action?.Invoke(i));  //Overloads: Executes the specified delegate on the thread that owns the control's underlying window handle. Action is a delegate that contains a method to be called in the control's thread context.
        }

        public bool Remove(T item) => list.Remove(item);

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