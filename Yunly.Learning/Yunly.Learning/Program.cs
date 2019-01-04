#define DEBUG


using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;



using System.Text;
using System;
using System.Collections.Generic;

using Yunly.Learning.Syntex;

namespace Yunly.Learning
{

    class Program
    {
     
        static void Main(string[] args)
        {
            var list = new YunlyList2(10);

            list.Add(DateTime.Now.Millisecond);
            list.Add(DateTime.Now.Millisecond);
            list.Add(DateTime.Now.Millisecond);
            list.Add(DateTime.Now.Millisecond);
            list.Add(DateTime.Now.Millisecond);

          



            Console.WriteLine(DateTime.Now);
            Console.ReadKey();
        }


      
        static void Greeting(string name, Action<string> localGreet) => localGreet(name);

             
        static void EnglishGreating(string name) => Console.WriteLine($"Morning, {name}");
        static void FrenchGreating(string name) => Console.WriteLine($"Bonjour, {name}");

    }

  
}

