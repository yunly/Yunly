using System;
using Yunly.App.Crawler;

using OpenQA.Selenium;

using Yunly.App.Crawler.HalifaxMyRec;

namespace Yunly.App.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            updateRecDb();

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }


        private static void updateRecDb()
        {
            MyRecProgram rec = new MyRecProgram();

            rec.updateLocalDb();
        }


    }
}
