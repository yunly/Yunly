using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;

namespace Yunly.App.Crawler.Bank.Models
{
    public class CreditTransaction
    {
        public DateTime TradingDate { get; set; }
        public DateTime BillingDate { get; set; }

        public string TransactionDesc { get; set; }
        
        public  Currency TradingCurrency { get; set; }
        public decimal TradingAmmount { get; set; }

        public Currency BillingCurrency { get; set; }
        public decimal BillingAmmount { get; set; }

        public string CardEnding4digits { get; set; }


        public static CreditTransaction Parse(IWebElement tr)
        {
            


            return new CreditTransaction();
        }
    }


    public enum Currency
    {
        CAD,
        CNY,
        USD
    }



}
