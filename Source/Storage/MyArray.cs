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
            array = new T[size];
            this.size = size;
        }
        public int Count => size;
        public bool isEmpty { get => size == 0 ? true : false; }
        public void Clear()
        {
            array = new T[0];
            size = 0;
        }
        public void Insert(int index, T item)
        {
            if (index >= 0 && index < size)
            {
                ++size;
                Array.Resize(ref array, size);
                for (int i = size - 1; i > index; --i)
                    array[i] = array[i - 1];
                array[index] = item;

            }
            else if (index < 0)
                AddFront(item);
            else
                Add(item);
        }
        public void Add(T item)
        {
            ++size;
            Array.Resize(ref array, size);
            array[size - 1] = item;
        }
        public void AddFront(T item)
        {
            ++size;
            Array.Resize(ref array, size);
            for (int i = size - 1; i > 0; --i)
                array[i] = array[i - 1];
            array[0] = item;
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
            if (index >= size || index < 0)
                throw new IndexOutOfRangeException(nameof(index));

            size--;
            if (index < size)
            {
                Array.Copy(array, index + 1, array, index, size - index);
            }
        }
        public void Remove(T item) => RemoveAt(IndexOf(item));
        //public void Change(T item1, T item2)
        //{
        //    int index = IndexOf(item1);
        //    if (index == -1)
        //        throw new IndexOutOfRangeException(nameof(item1));
        //    RemoveAt(index);
        //    Insert(index, item2);
        //}
        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= size))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
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
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }
        object IEnumerator.Current //Метод должен возвращать текущий элемент списка.
        {
            get { return Current; }
        }
        public void Dispose() { }
    }
}
