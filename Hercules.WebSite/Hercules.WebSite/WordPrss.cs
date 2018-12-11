using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


using Yunly.Net.SeleniumAPI;

using HtmlAgilityPack;

namespace Hercules.WebSite
{
    public class WordPrss
    {
        IWebDriver driver;

        private const string pageUrl = @"http://herculesslr.com/wp-admin/edit.php?post_type=page";
        private const string loginUrl = @"http://www.herculesslr.com/wp-login.php?jetpack-sso-show-default-form=1";

        public const string STATEMENT = "[sc name=\"statement\"]";

        HtmlTranslator translator = new HtmlTranslator();

        WebDriverWait wait;

        public WordPrss(IWebDriver d)
        {
            driver = d;
            wait = new WebDriverWait(d, TimeSpan.FromMinutes(1));
        }

        ~WordPrss()
        {
            driver.Dispose();
            driver.Quit();
            driver.Close();
        }

        
        public void login(string username, string password)
        {
            driver.Navigate().GoToUrl(loginUrl);
            


            IWebElement loginId = driver.FindElement(By.Id("user_login"));
            IWebElement passwordId = driver.FindElement(By.Id("user_pass"));
            IWebElement submitId = driver.FindElement(By.Id("wp-submit"));

            loginId.Clear();
            passwordId.Clear();

            loginId.SendKeys(username);
            passwordId.SendKeys(password);

            
            submitId.Click();

            try
            {
                var loginError = wait.Until(d => d.FindElement(By.Id("login_error")));
                driver.Navigate().GoToUrl(loginUrl);



                loginId = driver.FindElement(By.Id("user_login"));
                passwordId = driver.FindElement(By.Id("user_pass"));
                submitId = driver.FindElement(By.Id("wp-submit"));

                loginId.Clear();
                passwordId.Clear();

                loginId.SendKeys(username);
                passwordId.SendKeys(password);


                submitId.Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }


            

            // goto "https://herculesslr.com/wp-admin/index.php"
        }

        /// <summary>
        /// <li><a href="/?page_id=5989">Aqua Green Superdan Rope</a></li>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetPageIdFromLink(string url)
        {
            string pattern = @"^.+=(\d{4}).+$";
            var match = Regex.Match(url, pattern);

            return match == null || match.Groups.Count != 2 ? null : match.Groups[1].Value;
        }


        public string BuildUrl(string pageId)
        {
            return $"https://herculesslr.com/wp-admin/post.php?post={pageId}&action=edit";
        }


        public void translateFrench()
        {
            var frenchPageList = listAllFrenchPages();

            foreach (var page in frenchPageList)
            {
                updatePageText(page.url);
                //break;
            }
        }

        public string getContentFromUrl(string pageId)
        {
            var url = BuildUrl(pageId);
            driver.Navigate().GoToUrl(url);

            var contentElement = driver.FindElement(By.Id("content"));

            return contentElement.Text;
        }


        public Boolean compareTableId(string htmlEn, string htmlFr)
        {
            var documentEn = new HtmlDocument();
            documentEn.LoadHtml(htmlEn);

            var documentFr = new HtmlDocument();
            documentFr.LoadHtml(htmlFr);


            var tablesEn = documentEn.DocumentNode.SelectNodes("//table");
            var tablesFr = documentFr.DocumentNode.SelectNodes("//table");


            if (tablesEn == null && tablesFr == null) return true;

            if (tablesEn.Count == tablesFr.Count)
            {
                for(int i=0;i<tablesEn.Count;i++)
                {
                    if (tablesEn[i].Id != tablesFr[i].Id) return false;
                }
                return true;
            }

            return false;

        }



        public string textAfterAddStatement(string text)
        {
            if (text.Contains(STATEMENT)) return text;

            string pattern = @".*(</div>)$";
                     
            return Regex.Replace(text, pattern, $"{STATEMENT} </div>");
        }

        public void addStatements(List<string> pageIds, Action<string> doAction)
        {
            foreach (var pageId in pageIds)
                addStatement(pageId);
        }

        public void addStatement(string pageId)
        {
            var url = BuildUrl(pageId);

            driver.Navigate().GoToUrl(url);

            var contentElement = wait.Until(d => d.FindElement(By.Id("content")));

            var content = textAfterAddStatement(contentElement.Text);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", contentElement, content);


            IWebElement submitdiv = driver.FindElement(By.Id("submitdiv"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('class','postbox');", submitdiv);

            // Save Draft
            //IWebElement saveElement = driver.FindElement(By.Id("save-post"));

            //Update
            IWebElement saveElement = driver.FindElement(By.Id("publish"));

            saveElement.Click();

        }




        public List<(string title, string url, string outerHtml)> printAllPages(string text)
        {
            var pages = new List<(string title, string url, string outerHtml)>();
            var frenchPages = listAllFrenchPages();

            HtmlTranslator translator = new HtmlTranslator();

            foreach (var page in frenchPages)
            {
                driver.Navigate().GoToUrl(page.url);

                var contentElement = driver.FindElement(By.Id("content"));


                var element = translator.getHtmlByText(contentElement.Text, text);

                if (element != null)
                    pages.Add((page.text, page.url, element));

                break;
            }

            return pages;
        }


        #region Private Method


       

        private void updatePageText(string url)
        {
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(url);

            var contentElement = driver.FindElement(By.Id("content"));

            var content = convertToFrench(contentElement.Text);
                        

            //Console.WriteLine("=====original:====");
            //Console.WriteLine(contentElement.Text);
            //Console.WriteLine("=====translated:====");
            //Console.WriteLine(content);


            //return;

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", contentElement, content);


            IWebElement submitdiv = driver.FindElement(By.Id("submitdiv"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('class','postbox');", submitdiv);

            // Save Draft
            //IWebElement saveElement = driver.FindElement(By.Id("save-post"));

            //Update
            IWebElement saveElement = driver.FindElement(By.Id("publish"));

            saveElement.Click();
        }



        private string convertToFrench(string input)
        {
            return translator.replaceAllTable(input);            
        }




        private List<(string text, string url)> listAllFrenchPages()
        {

            driver.Navigate().GoToUrl(pageUrl);


            List<(string, string)> pages = new List<(string, string)>();

            var pageElements = driver.FindElements(By.ClassName("row-title"));

            foreach (var page in pageElements)
            { 
                if (page.Text.Length > 2 && page.Text.Substring(page.Text.Length - 3).Equals(" fr", StringComparison.CurrentCultureIgnoreCase))
                    pages.Add((page.Text, page.GetAttribute("href")));
            }

            return pages;
        }



        private string getEditUrl(string pageId)
        {
            return string.Format($"http://herculesslr.com/wp-admin/post.php?post={pageId}&action=edit");
        }

        private void SavePage(string pageId, string content)
        {

            driver.Navigate().GoToUrl(getEditUrl(pageId));
            
            IWebElement contentElement = driver.FindElement(By.Id("content"));


          
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", contentElement, content);


            IWebElement submitdiv = driver.FindElement(By.Id("submitdiv"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('class','postbox');", submitdiv);

            IWebElement saveElement = driver.FindElement(By.Id("save-post"));
            saveElement.Click();

        }

        #endregion

    }
}
