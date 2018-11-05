using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Yunly.Net.SeleniumAPI;

using HtmlAgilityPack;

namespace Hercules.WebSite
{
    public class WordPrss
    {
        IWebDriver driver;

        private const string pageUrl = @"http://herculesslr.com/wp-admin/edit.php?post_type=page";
        private const string loginUrl = @"http://www.herculesslr.com/wp-login.php?jetpack-sso-show-default-form=1";

        HtmlTranslator translator = new HtmlTranslator();

        public WordPrss()
        {
            driver = SeleniumFactory.createChromeDriver();
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

            loginId.SendKeys(username);
            passwordId.SendKeys(password);

            submitId.Click();
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
