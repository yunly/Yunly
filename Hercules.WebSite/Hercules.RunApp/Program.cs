﻿using System;
using System.IO;
using System.Text;
using System.Data;
using Hercules.WebSite;
using Hercules.ExportToExcel;
using System.Collections.Generic;



namespace Hercules.RunApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please input English:");
            string input = Console.ReadLine();

            while (!input.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
            {
                var result = LanguageTranslator.translateToFrench(input);
                
                Console.WriteLine(result);

                Console.WriteLine("Please input English:");
                input = Console.ReadLine();
            }

            //testExcelApp();
            //testWordPress();

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();               
        }

        static void testWordPress()
        {
            var user = @"zhuang@herculesslr.com";
            var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";

            WordPrss wordPress = new WordPrss();

            wordPress.login(user, password);

            var matchText = @"Questions? Quotes? Catalogue? Call or email: 1 877 461 4876";

            foreach (var page in wordPress.printAllPages(matchText))
            {
                Console.WriteLine(page.title);
                Console.WriteLine(page.url);
                Console.WriteLine(page.outerHtml);
                Console.WriteLine("---------------------------\n");
            }


        }


        static void testExcelApp()
        {
            DataTable table = new DataTable();

            table.Columns.Add("name", typeof(string));
            table.Columns.Add("age", typeof(int));

            table.Rows.Add("Marry", 21);
            table.Rows.Add("Jack", 23);
            table.Rows.Add("Peter", 24);


            FileInfo file = new FileInfo(@"C:\Users\zhuang\website\employee.xlsx");

            var excelApp = new ExcelBuilder();

            excelApp.Import(table, file, true, true, "Employee");



        }

        static void testHtmlNode()
        {
            var path1 = @"C:\Users\zhuang\website\French\chain_en.html";

            var frenchPath = @"C:\Users\zhuang\website\French\HerculesSLR_2018_Catalogue_FRENCH_FIN_02_UPDATED_BLEED FR-lo-res.html";

            var newPath = @"C:\Users\zhuang\website\French\chain_fr.html";

            var translator = new HtmlTranslator();

            //translator.replaceAllTable(frenchPath, path1, newPath);

            translator.getInnerTextFromNode();

        }

        static void translateHtml()
        {

            using (StreamReader sr = new StreamReader(@"C:\Users\zhuang\website\French\chain_en.html", true))
            {

                var htmlText = sr.ReadToEnd();

                var result = LanguageTranslator.translateHtmlToFrench(htmlText);

                using (StreamWriter sw = new StreamWriter(@"C:\Users\zhuang\website\French\french.html"))
                {
                    sw.Write(result);
                }
            }
        }
    }
}
