using System;
using System.IO;
using System.Text;
using Hercules.WebSite;

namespace Hercules.RunApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = LanguageTranslator.translateToFrench("Hello");

            Console.WriteLine(result);



            using (StreamReader sr = new StreamReader(@"C:\Users\zhuang\website\French\english.html", true))
            {

                var htmlText = sr.ReadToEnd();


                result = LanguageTranslator.translateHtmlToFrench(htmlText);

                using (StreamWriter sw = new StreamWriter(@"C:\Users\zhuang\website\French\french.html"))
                {
                    sw.Write(result);
                }


            }




            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
