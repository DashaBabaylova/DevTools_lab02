using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private  T[] array;

        private int count = 0;

        public int Capacity { get; }

        public int Count { get { return count; } }

        public Stack(int stack_capacity = 100)
        {
            if (stack_capacity > 0)
            {
                this.Capacity = stack_capacity;
                this.array = new T[stack_capacity];
            } else
            {
                throw new InvalidOperationException("Stack capacity must be greater than zero");
            }
        }

        public void Push(T element)
        {
            if(this.Count != array.Length)
            {
                this.array[count++] = element;
            } else
            {
                throw new InvalidOperationException("Stack is full.Unable to add element");
            }
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
            return this.array[--count];
        }

        public T Top()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }
            return this.array[count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {

            if (count == 0)
            {
                yield break;
            }
            for(int i = count - 1; i >= 0; i--)
            {
                yield return this.array[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
