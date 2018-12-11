using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using AccountBook.Models;

namespace AccountBook
{
    public class AccountBookHome
    {
        private IAccountRepository repository;
        private readonly ICommand addTransactionCommand;
        private readonly ICommand delTransactionCommand;
        private readonly ICommand modTransactionCommand;

        public AccountBookHome(
            IAccountRepository repo,
            ICommand addTransaction,
            ICommand delTransaction,
            ICommand modTransaction
            )
        {
            repository = repo;
            this.addTransactionCommand = addTransaction;
            this.delTransactionCommand = delTransaction;
            this.modTransactionCommand = modTransaction;
        }



        public Bill openBill(string billName)
        {
            try
            {
                return repository.Bills[billName];
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
        }

        public void AddTransaction(Transaction trans)
        {
            addTransactionCommand.execute(trans, null);
        }

        public void DelTransaction(Transaction trans)
        {
            delTransactionCommand.execute(null, trans);
        }

        public void ModTransaction(Transaction newTrans, Transaction oldTrans)
        {
            modTransactionCommand.execute(newTrans, oldTrans);
        }





    }
}
