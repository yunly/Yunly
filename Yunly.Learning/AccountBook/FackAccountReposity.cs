using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountBook.Models;

namespace AccountBook
{
    public class FackAccountReposity : IAccountRepository
    {
        public Dictionary<string, Bill> Bills => new Dictionary<string, Bill>
        {
            ["TD Bank"] = new CreditBill { BillName="TD Bank" },
            ["BoC"] = new CreditBill { BillName = "Boc" }
        };

        public void addBill(string billName)
        {
            Bills[billName] = new CreditBill { BillName = billName };
        }

        public void delBill(string billName)
        {
            Bills.Remove(billName);
        }
    }
}
