using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class CustomQueue<T> : AbstractCollection<T>
        where T : class
    {
        public CustomQueue() : base()
        {
        }

        public void Enqueue(T item) => Add(item);

        public T Dequeue()
        {
            T firstItem = _array[0];
            for (int i = 1; i < _pointer; i++)
            {
                _array[i - 1] = _array[i];
            }
            _array[--_pointer] = default;
            return firstItem;
        }
    }
}
