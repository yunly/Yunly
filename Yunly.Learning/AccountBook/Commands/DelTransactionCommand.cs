using System;
using System.Collections.Generic;
using System.Text;
using AccountBook.Models;

namespace AccountBook.Commands
{
    public class DelTransactionCommand : ICommand
    {
        private readonly Bill bill;

        public DelTransactionCommand(Bill bill)
        {
            this.bill = bill;
        }

        public void execute(Transaction newTrans, Transaction oldTrans)
        {
            bill.DelTransaction(oldTrans);
        }
    }
}
