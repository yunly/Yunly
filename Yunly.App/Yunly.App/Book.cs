using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Yunly.Net.SeleniumAPI;
using Yunly.App.Crawler.Bank.Models;
using System.IO;

namespace Yunly.App.Crawler
{
    public class Book
    {
        protected IWebDriver driver = SeleniumFactory.createChromeDriver();

        public string pageUrl { get; set; }

        public string OutPutPath { get; set; }

        public Func<string, By> title { get; set; }
        public Func<string, By> body { get; set; }
        public Func<string, By> next { get; set; }

        
        public void start()
        {
       
            string title;
            string content;
            string nextUrl = pageUrl;
            bool hasNext = true;


            using (StreamWriter sw = new StreamWriter(OutPutPath, true, Encoding.UTF8))
            {
                while (hasNext)
                {
                    (title, content, hasNext, nextUrl) = getContent(nextUrl);

                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine(title + "\t" + nextUrl);
                    sw.WriteLine(title);
                    sw.WriteLine(content);
                    sw.WriteLine("\n\n\n");
                }
                sw.Flush();
            }
        }

        private (string, string, bool, string) getContent(string url)
        {
            driver.Navigate().GoToUrl(url);

            var content = driver.FindElement(By.Id("directs"));

            var title = content.FindElement(By.ClassName("jieqi_title")).Text;

            var body = content.FindElement(By.Id("content")).Text;

            var next = content.FindElement(By.ClassName("next"));

            bool hasNext = false;
            string nextPageUrl = "";
            if (next.Text == "下一章")
            {
                hasNext = true;
                nextPageUrl = next.GetAttribute("href");
            }

            return (title, body, hasNext, nextPageUrl);
        }


        
    }
}
