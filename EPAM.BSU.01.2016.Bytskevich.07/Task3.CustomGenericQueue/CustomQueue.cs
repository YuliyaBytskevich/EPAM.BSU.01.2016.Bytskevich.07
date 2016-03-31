using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.CustomGenericQueue
{
    public class CustomQueue<T>
    {
        public int Count { get; private set; }
        private const int initialCapacity = 10;
        private int capacity;
        private T[] elements = null;    

        public CustomQueue()
        {
            capacity = initialCapacity;
            elements = new T[capacity];
            Count = 0;
        }

        private class Enumerator: IEnumerator<T>
        {
            private T[] elements;
            int position = -1;

            public Enumerator(T[] elems)
            {
                elements = elems;
            }

            private IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)this;
            }

            public bool MoveNext()
            {
                position++;
                return (position < elements.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {
                // DO NOTHING
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return elements[position];
                    }

                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => Current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(elements);
        }

        public void Enqueue(T newElement)
        {
            CheckAndCorrectCapacityIfNeeded();
            elements[Count++] = newElement;
        }

        public T Dequeue()
        {
            if (Count > 0)
            {
                T result;
                result = elements[0];
                for (int i = 1; i < Count; i++)
                    elements[i - 1] = elements[i];
                Count--;
                CheckAndCorrectCapacityIfNeeded();
                return result;
            }
            else
                return default(T);
        }

        public T Peek()
        {
            if (Count <= 0)
                throw  new InvalidOperationException("The Queue is empty.");
            return elements[0];         
        }

        public void Clear()
        {
            capacity = initialCapacity;
            elements = new T[capacity];
            Count = 0;
        }

        private void CheckAndCorrectCapacityIfNeeded()
        {
            if (Count != 0 && ((double)Count / capacity > 0.95D || (double)Count / capacity < 0.85))
            {
                capacity = (int)Math.Ceiling(10D * (double)Count / 9);
                T[] tempQueue = new T[capacity];
                for (int i = 0; i < Count; i++)
                    tempQueue[i] = elements[i];
                elements = tempQueue;
            }
        }
    }

    
}
