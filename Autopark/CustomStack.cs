using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class CustomStack<T> : AbstractCollection<T>
        where T : class
    {
        public CustomStack() : base()
        {
        }

        public void Push(T item) => Add(item);

        public T Pop()
        {
            T lastItem = _array[--Count];
            _array[Count] = default;
            return lastItem;
        }
    }
}
