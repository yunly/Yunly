using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AccountBook.Models;

namespace AccountBook
{
    public interface IAccountRepository
    {
        Dictionary<string, Bill> Bills { get; }
        void addBill(string billName);
        void delBill(string billName);
    }
}
