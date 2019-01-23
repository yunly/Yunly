using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

using Yunly.Net.SeleniumAPI;
using Yunly.App.Crawler.Bank.Models;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Yunly.App.Crawler
{
    public class Infochip2
    {
        protected IWebDriver driver = SeleniumFactory.createChromeDriver();

        


        string name = "ho-admin";
        string password = "Yr092016";

        string url = @"https://www.infochip2.com/ic_online_v5/Members/Basic_User/Attribute_ModifyPage.aspx";


        public List<List<string>>  TotalResult = new List<List<string>>();

        public Infochip2()
        {

        }
        public void login()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            driver.Navigate().GoToUrl(@"https://www.infochip2.com/ic_online_v5/Login.aspx");

            var user = driver.FindElement(By.Id("ctl00_PageContentPlaceHolder_Login1_UserName"));
            var pass = driver.FindElement(By.Id("ctl00_PageContentPlaceHolder_Login1_Password"));

            var login = driver.FindElement(By.Id("ctl00_PageContentPlaceHolder_Login1_LoginButton"));

            user.SendKeys(name);
            pass.SendKeys(password);

            login.Click();


            wait.Until(d => d.Url == "https://www.infochip2.com/ic_online_v5/Members/Basic_User/Dashboard.aspx");
            
        }


        public void loadData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                        
            driver.Navigate().GoToUrl(url);

            ///ctl00_PageContentPlaceHolder_ui_attributesGridViewToolBar_ui_pageLabel
            ///(Page 2 of 108)
            var page = 1;
            var totalPage = 108;
            string pageString = "";
            var retries = 2;
            while (true)
            {
                pageString = $"(Page {page} of {totalPage})";


                wait.Until(d =>
                {
                    try
                    {
                        return d.FindElement(By.Id("ctl00_PageContentPlaceHolder_ui_attributesGridViewToolBar_ui_pageLabel")).Text == pageString;
                    }
                    catch (StaleElementReferenceException)
                    {
                        Console.WriteLine("Retry read page text.");
                        return false;
                    }
                });
 


                var trs = wait.Until(d => d.FindElements(By.CssSelector("#ctl00_PageContentPlaceHolder_attributesGridView tr")));

                //wait.Timeout = TimeSpan.FromSeconds(1);
                //wait.Until(d => d.FindElement(By.Id("")));

                Console.WriteLine(pageString);
                for (var i = 1; i < trs.Count; i++)
                {
                    var tds = trs[i].FindElements(By.TagName("td"));

                    List<string> line = new List<string>();
                    foreach (var td in tds)
                    {
                        line.Add(td.Text);
                    }

                    TotalResult.Add(line);
                }
                Console.WriteLine($"read {trs.Count - 1} lines");
                //var result = loadTable(table);

                //TotalResult.AddRange(result);


                if (page++ >= totalPage) break;

                Console.Write($"Turn to page {page}");


                retries = 2;
                while (retries-- >= 0)
                {

                    try
                    {
                        wait.Until(d => d.FindElement(By.CssSelector("#ctl00_PageContentPlaceHolder_ui_attributesGridViewToolBar_ui_nextBtn_jQueryButtonUpdatePanel span"))).Click();                        
                        break;
                    }
                    catch (StaleElementReferenceException) { Console.WriteLine("click next failed."); }
                }

                
            }
        }

        public List<List<string>> loadTable(IWebElement tbody)
        {
            
            var result = new List<List<string>>();


            var retries = 2;

            //IWebElement tbody = null;

            //while (retries-- >= 0)
            //{
            //    try
            //    {
            //        tbody = table.FindElement(By.TagName("tbody"));
            //        break;
            //    }
            //    catch (NoSuchElementException ex)
            //    {
            //        Console.WriteLine("Can't find tbody tag.");
            //    }
            //    catch (StaleElementReferenceException)
            //    { Console.WriteLine("Can't find tbody tag. staleelement error."); }
            //}


            IReadOnlyCollection<IWebElement> trs = null;

            retries = 2;

            while (retries-- >= 0)
            {
                try
                {
                    trs = tbody.FindElements(By.TagName("tr"));
                    break;
                }
                catch (StaleElementReferenceException) { }
            }

            

            foreach (var tr in trs)
            {
                var line = new List<string>();

                IReadOnlyCollection<IWebElement> tds = null;

                retries = 2;
                while (retries-- >= 0)
                {
                    try
                    {
                        tds = tr.FindElements(By.TagName("td"));
                        break;
                    }
                    catch (StaleElementReferenceException) { }
                }

                if (tds == null) continue;

                foreach (var td in tds)
                {
                    retries = 2;
                    while (retries-- >= 0)
                    {
                        try
                        {
                            line.Add(td.Text);
                            break;
                        }
                        catch (StaleElementReferenceException) { Console.WriteLine("Can't read td text."); }
                    }
                }

                result.Add(line);
            }

            
            return result;
        }
    }
}
