using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn6_Garage
{
    public interface ILimitedList<T> : IEnumerable<T>
    {
        T this[int index] { get; }

        int Count { get; }
        bool IsFull { get; }

        bool Add(T item);
        //IEnumerator<T> GetEnumerator();
        //void Print(Action<T> action);
        bool Remove(T item);
    }
}
