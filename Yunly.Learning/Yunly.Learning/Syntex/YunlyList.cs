using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Syntex
{
    public class YunlyList //: IEnumerable
    {
        private int capacity = 0;
        private int[] array;
        private int position;

        public YunlyList(int cap)
        {
            this.capacity = cap;
            array = new int[capacity];
            Clear();
        }

        public void Add(int item) => array[position++] = item;

        public void Clear()
        {
            position = 0;
            for (var i = 0; i < array.Length; i++)
                array[i] = 0;

        }
        
        public IEnumerator GetEnumerator()
        {
            foreach (var item in array)
                yield return item;
        }
    }
}
