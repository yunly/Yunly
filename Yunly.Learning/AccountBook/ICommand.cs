using System;
using System.Collections.Generic;
using System.Text;

using AccountBook.Models;

namespace AccountBook
{
    public interface ICommand
    {
        void execute(Transaction newTrans, Transaction oldTrans);
    }
}
