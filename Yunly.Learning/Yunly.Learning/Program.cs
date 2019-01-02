#define DEBUG


using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;



using System.Linq;
using System;
using System.Collections.Generic;

using Yunly.Learning.DesignPattern.Command;

namespace Yunly.Learning
{

    class GenericClass<T> where T : Comparer<T>
    {
        private T item;
        public GenericClass(T input)
        {
            item = input;
        }        
    }

    class MyComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            if (x.Equals(y)) return 0;

            return x.GetHashCode() > y.GetHashCode() ? 1 : -1;
        }
    }



    class Program
    {
     
        static void Main(string[] args)
        {

            MyComparer<int> comparer = new MyComparer<int>();

           

            

            Console.WriteLine(DateTime.Now);
        }

    }

  
}

