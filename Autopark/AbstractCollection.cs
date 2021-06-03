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
        protected int _pointer;

        public int Count { get { return _pointer; } }

        protected AbstractCollection()
        {
            _array = new T[8];
            _pointer = 0;
        }

        protected void Add(T item)
        {
            if (_pointer == _array.Length)
            {
                var newArray = new T[_array.Length * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }
            _array[_pointer++] = item;
        }

        public void Clear()
        {
            _array = new T[8];
            _pointer = 0;
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
            for (int i = 0; i < _pointer; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _pointer; i++)
            {
                yield return _array[i];
            }
        }
    }
}
