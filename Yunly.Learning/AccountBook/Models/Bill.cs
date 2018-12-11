using System;
using System.Collections.Generic;
using System.Linq;


namespace AccountBook.Models
{
    public abstract class Bill: ITransferable
    {
        
        public string BillName { get; set; }

        public List<Transaction> Transactions = new List<Transaction>();

        public int transAmount
        {
            get
            {
                return Transactions.Count;
            }
        }

        public Transaction lastTransaction
        {
            get
            {
                return Transactions[transAmount - 1];
            }
        }

        public abstract void Transfer(Bill to, Transaction trans);
              
        public abstract Transaction AddTransaction(Transaction trans);
        public abstract Transaction AddTransaction(decimal amount, DateTime time, Currency currency, string desc = "");
        public abstract Transaction AddTransaction(decimal amount, DateTime time, string desc = "");

        public abstract void DelTransaction(Transaction trans);

        public abstract void ModTransaction(Transaction newTrans, Transaction oldTrans);

        public decimal Aalance(Currency currency) => Transactions.Where(t => t.TransactionCurrency == currency).Sum(t => t.TransactionAmount);

        

    }
}
