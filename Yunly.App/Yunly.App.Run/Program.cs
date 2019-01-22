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
            Infochip2 app = new Infochip2();
            app.login();

            app.loadData();


            foreach (var line in app.TotalResult)
                Console.WriteLine(string.Join('\t', line));



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
