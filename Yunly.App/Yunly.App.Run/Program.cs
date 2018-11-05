using System;
using Yunly.App.Crawler;

using OpenQA.Selenium;


namespace Yunly.App.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var pageUrl = @"http://www.hetushu.com/book/382/219398.html";
            var path = @"C:\Users\zhuang\Documents\liuyun.txt";


            Book book = new Book()
            {
                pageUrl = pageUrl,
                OutPutPath = path,
                

            };

            



            book.start();

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
