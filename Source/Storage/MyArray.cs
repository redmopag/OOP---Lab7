using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source
{
    public class MyArray<T> : IEnumerable, IEnumerator
    {
        private T[] array;
        private int size;
        private int position = -1;

        public MyArray()
        {
            array = new T[0];
            size = 0;
        }
        public MyArray(int size)
        {
            if (size >= 0)
            {
                array = new T[size];
                this.size = size;
            }
            else
            {
                array = new T[0];
                size = 0;
            }
        }

        public int Count => size;
        public int Capacity => array.Length;
        public bool isEmpty { get => size == 0 ? true : false; }
        public void Clear()
        {
            array = new T[0];
            size = 0;
            position = -1;
        }
        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= size))
                throw new IndexOutOfRangeException(nameof(index));
        }
        private void TryResize()
        {
            ++size;
            if (array.Length < size)
                Array.Resize(ref array, array.Length == 0 ? 1 : array.Length * 2);
        }
        private void InsertAt(int index, T item)
        {
            TryResize();
            for (int i = size - 1; i > index; i--)
                array[i] = array[i - 1];
            array[index] = item;
        }
        public void Add(T item) => InsertAt(size, item);
        public void AddFront(T item) => InsertAt(0, item);
        public void Insert(int index, T item)
        {
            ThrowIfInvalid(index);
            InsertAt(index, item);
        }
        private int IndexOf(T x)
        {
            int i = 0;
            while ((i < size) && (!array[i].Equals(x)))
            {
                i++;
            }
            if (i == size)
            {
                return -1;
            }
            return i;
        }
        public void RemoveAt(int index)
        {
            ThrowIfInvalid(index);

            size--;
            if (index < size)
            {
                Array.Copy(array, index + 1, array, index, size - index);
            }
        }
        public void Remove(T item) => RemoveAt(IndexOf(item));
        public T this[int i]
        {
            get
            {
                ThrowIfInvalid(i);
                return array[i];
            }
            set
            {
                ThrowIfInvalid(i);
                array[i] = value;
            }
        }
        public bool Contains(T item)
        {
            int num = IndexOf(item);
            return num == -1 ? false : true;
        }
        //----------------------------------------------------------------
        // Foreach
        public IEnumerator GetEnumerator()
        {
            Reset();
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < size);
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return array[position]; }
        }
        public void Dispose() { }
    }
}
