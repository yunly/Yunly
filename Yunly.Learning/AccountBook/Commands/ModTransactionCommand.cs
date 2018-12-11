using System;
using System.Collections.Generic;
using System.Text;
using AccountBook.Models;

namespace AccountBook.Commands
{
    public class ModTransactionCommand : ICommand
    {
        private readonly Bill bill;

        public ModTransactionCommand(Bill bill)
        {
            this.bill = bill;
        }

        public void execute(Transaction newTrans, Transaction oldTrans)
        {
            bill.ModTransaction(newTrans, oldTrans);
        }
    }
}
