using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


        public override string ToString()
        {
            return string.Format($"{CardEnding4digits}\t{BillingDate.ToShortDateString()}\t{BillingAmmount}\t{TradingDate.ToShortDateString()} {TransactionDesc} {TradingCurrency}{TradingAmmount}");
        }

        /*
         <tr id="acc_no_1" values="4691350051293574|10223549|02800002091350051293574|1|156|20180810">
				    1	<td><script>formatDate('20180807')</script>2018/08/07</td>
					2	<td><script>formatDate('20180810')</script>2018/08/10</td>
					3	<td><script>
							formatAccno('4691350051293574');
							formatDpanAccNo('');
						</script>3574</td>
					4	<td>CCB8% F2F REWARD         .            US</td>
					5	<td>美元</td>
					6	<td>
							
							
							
							
									<span style="color:#d62f2f"></span>
									<span style="color:#ff6600"><script>FormatAmt('-11.44')</script>-11.44</span>
								
							
						</td>
					7	<td>人民币</td>
					8	<td>
							
												
							
							
								<span style="color:#ff6600">
									<script>FormatAmt('-78.35')</script>-78.35
								</span>
								
							
						</td>
						<!-- <td ><a href='javascript:void(0)' onclick='xiangqing("1")'>详情</></td>-->
					</tr>
             */
        public static CreditTransaction Parse(IReadOnlyCollection<IWebElement> tds)
        {
            CreditTransaction transaction = new CreditTransaction();

            var fields = tds.ToArray();

            transaction.TradingDate = DateTime.Parse(fields[0].Text);
            transaction.BillingDate = DateTime.Parse(fields[1].Text);
            transaction.CardEnding4digits = fields[2].Text;
            transaction.TransactionDesc = fields[3].Text;

            transaction.TradingCurrency = chsToEnm(fields[4].Text);

            transaction.TradingAmmount = decimal.Parse(fields[5].Text);

            transaction.BillingCurrency = chsToEnm(fields[6].Text);

            transaction.BillingAmmount = decimal.Parse(fields[7].Text);




            return transaction;
        }

        private static Currency chsToEnm(string currencyName)
        {
            switch (currencyName)
            {
                case "人民币":
                    return Currency.CNY;
                case "美元":
                    return Currency.USD;
                case "加拿大元":
                    return Currency.CAD;
                default:
                    return Currency.CNY;
            }
        }
    }


    public enum Currency
    {
        CAD,
        CNY,
        USD
    }



}
