using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public abstract class AbstractCollection<T> : IEnumerable<T>
        where T : class
    {
        protected T[] _array;
        //protected int Count;

        public int Count { get; protected set; }

        protected AbstractCollection()
        {
            _array = new T[8];
            Count = 0;
        }

        protected void Add(T item)
        {
            if (Count == _array.Length)
            {
                var newArray = new T[_array.Length * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }
            _array[Count++] = item;
        }

        public void Clear()
        {
            _array = new T[8];
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var elem in _array)
            {
                if (elem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
