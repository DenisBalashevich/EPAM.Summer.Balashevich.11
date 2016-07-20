using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueTask
{
    class Queue<T> : IEnumerable<T>
    {
        private static int initialArrayCapacity = 8;
        private int currentSize;
        private int first;
        private int end;
        private T[] queue;


        public Queue() : this(initialArrayCapacity) { }

        public Queue(int capacity)
        {
            if (capacity < 0)
                EmptyQueue(initialArrayCapacity);
            EmptyQueue(capacity);
        }

        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(null, collection))
                EmptyQueue(initialArrayCapacity);
            EmptyQueue(collection.Count());
            foreach (var a in collection)
                this.Enqueue(a);
        }



        public void Enqueue(T temp)
        {
            if (ReferenceEquals(temp, null))
                throw new ArgumentNullException();
            if (currentSize == queue.Length)
            {
                NewDimensionOfArray();
            }
            queue[end] = temp;
            end = (++end) % queue.Length;
            currentSize++;
        }



        public T Peek()
        {
            if (IsEmpty() == true)
                throw new Exception("Queue is empty");
            return queue[first];
        }

        public T Dequeue()
        {
            if (IsEmpty() == true)
                throw new Exception("Queue is empty");
            first = first % queue.Length;
            T returnValue = queue[first];
            DeleteHead();
            return returnValue;
        }

        public void Clear()
        {
            if (first < end)
            {
                Array.Clear((Array)queue, first, currentSize);
            }
            else
            {
                Array.Clear((Array)queue, first, queue.Length - first);
                Array.Clear((Array)queue, 0, end);
            }
            EmptyQueue(0);
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        private void DeleteHead()
        {
            queue[first] = default(T);
            first++;
            currentSize--;
        }

        private void EmptyQueue(int capacity)
        {
            queue = new T[capacity];
            currentSize = end = first = 0;
        }

        private void NewDimensionOfArray()
        {
            T[] NewArray = new T[queue.Length * 2];
            for (int i = 0; i < currentSize; i++)
            {
                NewArray[i] = queue[first];
                first = (++first) % queue.Length;
            }
            queue = NewArray;
            first = 0;
            end = currentSize;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(queue);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct CustomIterator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private readonly T[] collection;
            private int currentIndex;

            public CustomIterator(T[] collection)
            {
                this.currentIndex = -1;
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count())
                    {
                        throw new InvalidOperationException();
                    }
                    return collection[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count())
                    {
                        throw new InvalidOperationException();
                    }
                    return (object)collection[currentIndex];
                }
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                return ++currentIndex < collection.Count();
            }

            void IDisposable.Dispose() { }
        }
    }
}
