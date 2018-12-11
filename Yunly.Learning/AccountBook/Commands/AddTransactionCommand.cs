using System;
using System.Collections.Generic;
using System.Text;
using AccountBook.Models;

namespace AccountBook.Commands
{
    public class AddTransactionCommand : ICommand
    {
        private readonly Bill bill;

        public AddTransactionCommand(Bill bill)
        {
            this.bill = bill;
        }

        public void execute(Transaction newTrans, Transaction oldTrans)
        {
            bill.AddTransaction(newTrans);
        }
    }
}
