using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


using Yunly.Net.SeleniumAPI;
using Yunly.App.Crawler.Bank.Models;

namespace Yunly.App.Crawler.Bank
{
    public abstract class BankWeb
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        protected IWebDriver driver = SeleniumFactory.createChromeDriver();

        
        


        public abstract void Login();

        public abstract List<CreditTransaction> GetCreditTransactions();



    }
}
