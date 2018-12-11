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
    


    class AsyncNet
    {
        public static Task<HttpResponseHeaders> getTitleText(string url)
        {

            var httpClient = new HttpClient();

            var httpTask = httpClient.GetAsync(url);

            return httpTask.ContinueWith(response=>response.Result.Headers);          
        }
    }
   

    class Program
    {

     
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
        }

        static void testCommand()
        {
         
        }
    }

  
}

