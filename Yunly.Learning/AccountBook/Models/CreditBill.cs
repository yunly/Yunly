using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBook.Models
{
    public class CreditBill : Bill
    {
        public override Transaction AddTransaction(Transaction trans)
        {
            Transactions.Add(trans);
            return lastTransaction;
        }

        public override Transaction AddTransaction(decimal amount, DateTime time, Currency currency, string desc = "")
        {
            var trans = new Transaction
            {
                TransactionAmount = amount,
                TransactionTime = time,
                TransactionCurrency = currency,
                Description = desc
            };

            return AddTransaction(trans);
        }

        public override Transaction AddTransaction(decimal amount, DateTime time, string desc = "")
        {
            return AddTransaction(amount, time, Currency.CAD, desc);
        }


        public override void DelTransaction(Transaction trans)
        {
            Transactions.Remove(trans);
        }

        public override void ModTransaction(Transaction newTrans, Transaction oldTrans)
        {
            DelTransaction(oldTrans);
            AddTransaction(newTrans);
        }

        public override void Transfer(Bill to, Transaction trans)
        {
            throw new NotImplementedException();
        }
    }
}
