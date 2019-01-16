using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Yunly.Learning.Syntex
{
    public class YunlyList3<T> : IList<T>
    {
        private T[] items;
        private int capacity;
        private int size;


        public YunlyList3(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException("Capacity must greater than 0");

            items = new T[capacity];
            size = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= size) throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index >=size) throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear() => Array.Clear(items, 0, size);

        public bool Contains(T item) {
            for (var i = 0; i < size; i++)
                if (item.Equals(items[i])) return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
