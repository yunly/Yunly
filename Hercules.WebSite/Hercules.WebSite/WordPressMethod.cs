using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hercules.WebSite.WordPress
{
    public class WordPressMethod
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private const string loginUrl = @"http://www.herculesslr.com/wp-login.php?jetpack-sso-show-default-form=1";

        public WordPressMethod(IWebDriver d)
        {
            driver = d;
            wait = new WebDriverWait(d, TimeSpan.FromMinutes(1));
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
        }


        public string getContentByPageId(string pageId)
        {
            var url = BuildUrl(pageId);
            driver.Navigate().GoToUrl(url);
            try
            {
                var contentElement = wait.Until(d => d.FindElement(By.Id("content")));

                return contentElement.Text;
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
        }


        public string saveContent(string pageId, string contentText)
        {
            var url = BuildUrl(pageId);

            driver.Navigate().GoToUrl(url);

            var contentElement = wait.Until(d => d.FindElement(By.Id("content")));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", contentElement, contentText);

            IWebElement submitdiv = driver.FindElement(By.Id("submitdiv"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('class','postbox');", submitdiv);

            // Save Draft
            //IWebElement saveElement = driver.FindElement(By.Id("save-post"));

            //Update
            IWebElement saveElement = driver.FindElement(By.Id("publish"));

            saveElement.Click();

            return getContentByPageId(pageId);
        }


        #region Private Method

        private string BuildUrl(string pageId)
        {
            return $"https://herculesslr.com/wp-admin/post.php?post={pageId}&action=edit";
        }


        #endregion
    }
}
