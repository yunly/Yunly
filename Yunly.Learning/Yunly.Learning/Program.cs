#define DEBUG


using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;



using System.Linq;
using System;
using System.Collections.Generic;

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

     
        static async Task Main(string[] args)
        {

            var url = @"http://apress.com";
            Console.WriteLine("Open {0}", url);
            var title = await AsyncNet.getTitleText(url);

            foreach (var head in title)
            {
                Console.WriteLine($"{head.Key}:{string.Join(',', head.Value)}");
            }






            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }       
    }

  
}

