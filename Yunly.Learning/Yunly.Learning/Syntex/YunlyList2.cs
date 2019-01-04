using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Syntex
{
    public class YunlyList2 : IEnumerator
    {
        int[] array;
        int postion = 0;

        public YunlyList2(int capacity)
        {
            array = new int[capacity];
        }

        public void Add(int item)
        {
            array[postion++] = item;
        }

        public object Current => array[postion];

        public bool MoveNext()
        {
            if (postion++ < array.Length) return true;

            return false;
        }

        public void Reset()
        {
            postion = 0;
        }
    }
}
