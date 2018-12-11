using System;
using System.Collections.Generic;
using System.Text;

using AccountBook.Models;

namespace AccountBook
{
    public interface ITransferable
    {
        void Transfer(Bill to, Transaction trans);
    }
}
