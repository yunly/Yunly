using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


using Yunly.App.Crawler.Bank.Models;

namespace Yunly.App.Crawler.Bank
{
    public class Ccb : BankWeb
    {
        const string LoginUrl = @"https://ibsbjstar.ccb.com.cn/CCBIS/V6/common/login.jsp";
        private string creditUrl;

        public override void Login()
        {


            driver.Navigate().GoToUrl(LoginUrl);

            setLoginCookie();


            driver.SwitchTo().Frame(driver.FindElement(By.Id("fQRLGIN")));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));


            IWebElement ElementUser = wait.Until(d => d.FindElement(By.Id("USERID")));
            IWebElement ElementPass = wait.Until(d => d.FindElement(By.Id("LOGPASS")));
            IWebElement ElementLogin = wait.Until(d => d.FindElement(By.Id("loginButton")));

            ElementUser.SendKeys(this.UserName);
            ElementPass.SendKeys(this.Password);
            ElementLogin.Click();

            ///
            /// sms alert
            ///
            try
            {

                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var userid = js.ExecuteScript("return DAT_USERBASE.USERID;") as string;
            var branchid = js.ExecuteScript("return DAT_USERBASE.BRANCHID;") as string;
            var skey = js.ExecuteScript("return DAT_USERBASE.SKEY;") as string;

            //get specific link, eg. creditcard history term billing
            this.creditUrl = CreditCardUrl(userid, branchid, skey);

        }

        public override List<CreditTransaction> GetCreditTransactions()
        {

            List<CreditTransaction> transactions = new List<CreditTransaction>();

            driver.Navigate().GoToUrl(creditUrl);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            var table = wait.Until(d => d.FindElement(By.Id("result5")));

            foreach (var row in table.FindElements(By.TagName("tr")))
            {

                var tds = row.FindElements(By.TagName("td"));

                if (tds == null || tds.Count == 0)
                    continue;

                //next page
                if (tds.Count == 1)
                {

                    continue;
                }

               // transactions.Add(CreditTransaction.Parse(tds));
            }






            return new List<CreditTransaction>();
        }

        private string CreditCardUrl(string userid, string branchid, string skey)
        {
            return string.Format("https://ibsbjstar.ccb.com.cn/CCBIS/B2CMainPlatP1?SERVLET_NAME=B2CMainPlatP1&CCB_IBSVersion=V6&PT_STYLE=1&USERID={0}&BRANCHID={1}&SKEY={2}&TXCODE=XE1112", userid, branchid, skey);           
        }

        private void setLoginCookie()
        {

            driver.Manage().Cookies.AddCookie(new Cookie("ADVC", "3676ed847d31d2"));
            driver.Manage().Cookies.AddCookie(new Cookie("ASL", "17743,0000u,8eb1951e"));
            driver.Manage().Cookies.AddCookie(new Cookie("FAVOR", "||||||||||||||||||||||||||||||||||||||||||||||||||"));
            driver.Manage().Cookies.AddCookie(new Cookie("TC", "551963834_772887389_95273401"));
            driver.Manage().Cookies.AddCookie(new Cookie("TTC", "773719721778237764"));
        }

    }
}
