using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Navigate().GoToUrl(url);

            
            

            while (true)
            {
                var table = wait.Until(d => d.FindElement(By.Id("ctl00_PageContentPlaceHolder_attributesGridView")));

               

                var result = loadTable(table);

                TotalResult.AddRange(result);





                var next = wait.Until(d => d.FindElement(By.Id("ctl00_PageContentPlaceHolder_ui_attributesGridViewToolBar_ui_nextBtn_jQueryButtonUpdatePanel")));

                var retries = 2;
                Boolean isEnd = false;
                while (retries-- >= 0)
                {
                    try
                    {
                        var hasNext = next.GetAttribute("disabled");
                        if (hasNext == "disabled")
                        {
                            isEnd = true;
                            
                        }
                        break;
                    }
                    catch (StaleElementReferenceException) { Console.WriteLine("Next.GetAttribute disabled failed."); }
                }

                if (isEnd) break;

                retries = 2;
               
                while (retries-- >= 0)
                {

                    try
                    {
                        next.FindElement(By.TagName("span")).Click();
                        
                        break;
                    }
                    catch (StaleElementReferenceException) { Console.WriteLine("click next failed."); }

                }

                
            }
        }

        public List<List<string>> loadTable(IWebElement table)
        {
            
            var result = new List<List<string>>();


            var retries = 5;

            IWebElement tbody = null;

            while (retries-- >= 0)
            {
                try
                {
                    tbody = table.FindElement(By.TagName("tbody"));
                    break;
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("Can't find tbody tag.");
                }
                catch (StaleElementReferenceException)
                { Console.WriteLine("Can't find tbody tag. staleelement error."); }
            }


            var trs = tbody.FindElements(By.TagName("tr"));

            foreach (var tr in trs)
            {
                var line = new List<string>();

                var tds = tr.FindElements(By.TagName("td"));

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
