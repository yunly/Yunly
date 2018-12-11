using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;

using Yunly.Net.SeleniumAPI;

using HtmlAgilityPack;

using Hercules.WebSite.WordPress;


namespace Hercules.WebSite
{
    public class WordPressAutomation
    {
        IWebDriver driver = SeleniumFactory.createChromeDriver();

        WordPressMethod wordPress;


        public WordPressAutomation()
        {
            wordPress = new WordPressMethod(driver);
        }


        ~WordPressAutomation()
        {
            driver.Dispose();
            driver.Quit();
            driver.Close();
        }

        public void compareAllTables(string englishFile, string frenchFile)
        {
            var englishPageIds = getPageIds(englishFile).ToList();
            var frenchPageIds = getPageIds(frenchFile).ToList();

            var user = @"zhuang@herculesslr.com";
            var password = @"WbP^ICOCqCHfUeKUh)7oEgZ6";
            
            wordPress.login(user, password);

            for (var i = 0; i < englishPageIds.Count; i++)
            {
                Console.WriteLine($"Processing English({englishPageIds[i]}), French( {frenchPageIds[i]}) ");
                
                try
                {
                    var englishContent = wordPress.getContentByPageId(englishPageIds[i]);
                    var frenchContent = wordPress.getContentByPageId(frenchPageIds[i]);


                    var result = compareTableId(englishContent, frenchContent);

                    if (!result)
                    {
                        Console.WriteLine($"Found different table id in: English({englishPageIds[i]}), French( {frenchPageIds[i]}) ");
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine($"{ex.Message}, English({englishPageIds[i]}), French( {frenchPageIds[i]})");
                }
            }                       
        }



        private IEnumerable<string> getPageIds(string path)
        {
            foreach (var line in File.ReadLines(path))
            {
                var pageId = GetPageIdFromLink(line);
                if (string.IsNullOrEmpty(pageId))
                    continue;
                else
                    yield return pageId;
            }
        }

        private Boolean compareTableId(string htmlEn, string htmlFr)
        {
            var documentEn = new HtmlDocument();
            documentEn.LoadHtml(htmlEn);

            var documentFr = new HtmlDocument();
            documentFr.LoadHtml(htmlFr);


            var tablesEn = documentEn.DocumentNode.SelectNodes("//table");
            var tablesFr = documentFr.DocumentNode.SelectNodes("//table");


            if (tablesEn == null && tablesFr == null) return true;

            if (tablesEn == null || tablesFr == null) return false;

            if (tablesEn.Count == tablesFr.Count)
            {
                for (int i = 0; i < tablesEn.Count; i++)
                {
                    if (tablesEn[i].Id != tablesFr[i].Id) return false;
                }
                return true;
            }

            return false;

        }

        private string GetPageIdFromLink(string url)
        {
            string pattern = @"^.+=(\d{4}).+$";
            var match = Regex.Match(url, pattern);

            return match == null || match.Groups.Count != 2 ? null : match.Groups[1].Value;
        }
    }
}
