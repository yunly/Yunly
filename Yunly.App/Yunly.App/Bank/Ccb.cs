using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Yunly.App.Crawler.Bank
{
    public class Ccb : BankWeb
    {
        const string LoginUrl = @"https://ibsbjstar.ccb.com.cn/CCBIS/V6/common/login.jsp";
        private string creditUrl;

          public override void Login()
        {
            driver.Navigate().GoToUrl(LoginUrl);

            driver.Manage().Cookies.AddCookie(new Cookie("ccbcustomid", "b8f3bf8509812903iVIwYJZAYBxB1RPQwObM1531150105115pQ4QF91bQAeX44ojfb4Had4ad8383565a223d77089f9312ddc95"));

            driver.SwitchTo().Frame(driver.FindElement(By.Id("fQRLGIN")));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            

            IWebElement ElementUser = wait.Until(d => d.FindElement(By.Id("USERID")));

            IWebElement ElementPass = wait.Until(d => d.FindElement(By.Id("LOGPASS")));

            IWebElement ElementLogin = wait.Until(d => d.FindElement(By.Id("loginButton")));


            ElementUser.SendKeys(this.UserName);

            ElementPass.SendKeys(this.Password);

            ElementLogin.Click();

            driver.SwitchTo().Alert().Accept();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            var userid = js.ExecuteScript("return DAT_USERBASE.USERID;") as string;
            var branchid = js.ExecuteScript("return DAT_USERBASE.BRANCHID;") as string;
            var skey = js.ExecuteScript("return DAT_USERBASE.SKEY;") as string;


            this.creditUrl = CreditCardUrl(userid, branchid, skey);

        }

        public override List<CreditTransaction> GetCreditTransactions()
        {
            

            driver.Navigate().GoToUrl(creditUrl);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            var table = wait.Until(d => d.FindElement(By.Id("result5")));

            foreach (var row in table.FindElements(By.TagName("tr")))
            {
                string tdvalue = "";
                foreach (var td in row.FindElements(By.TagName("td")))
                {
                    tdvalue += tdvalue == "" ? "\t" + td.Text : td.Text;
                }

                Console.WriteLine(tdvalue);
            }






            throw new NotImplementedException();
        }

        private string CreditCardUrl(string userid, string branchid, string skey)
        {
            return string.Format("https://ibsbjstar.ccb.com.cn/CCBIS/B2CMainPlatP1?SERVLET_NAME=B2CMainPlatP1&CCB_IBSVersion=V6&PT_STYLE=1&USERID={0}&BRANCHID={1}&SKEY={2}&TXCODE=XE1112", userid, branchid, skey);
            


        }


    }
}
