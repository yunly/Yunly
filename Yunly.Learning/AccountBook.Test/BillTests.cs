using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

using AccountBook.Models;

namespace AccountBook.Test
{
    public class BillTests
    {
        Mock<IAccountRepository> mock = new Mock<IAccountRepository>();

        public BillTests()
        {
            mock.Setup(m => m.Bills).Returns(
                new Dictionary<string, Bill>
                {
                    ["TD Bank"] = new CreditBill { BillName = "TD Bank" },
                    ["BoC"] = new CreditBill { BillName = "Boc" }
                }
            );
        }

        [Fact]
        public void Can_Select_Bill()
        {
            //arrange       
            var billName = "TD Bank";


            //act
            AccountBookHome book = new AccountBookHome(mock.Object);

            //assert
            Assert.Same(billName, book.openBill(billName).BillName);
        }

        [Fact]
        public void Test_Select_NotExist_Bill()
        {
            //arrange       
            var billName = "BOC Visa1";

            //act
            AccountBookHome book = new AccountBookHome(mock.Object);

            //assert
            Assert.Throws<KeyNotFoundException>(() => book.openBill(billName));
        }

        [Fact]
        public void Test_Add_Trans()
        {
            //arrange       
            var billName = "BoC";

            var amount = 10.23m;
            var transTime = new DateTime(2018, 11, 27);
            
            //act
            var book = new AccountBookHome(mock.Object);
            var bill = book.openBill(billName);

            var result = bill.AddTransaction(amount, transTime);

            //assert
            Assert.Equal(amount, result.TransactionAmount);
            Assert.Equal(transTime, result.TransactionTime);
            Assert.Equal(1, bill.Transactions.Count);
        }

        [Fact]
        public void Test_Del_Trans()
        {
            //arrange       
            var billName = "BoC";

            var amount = 10.23m;
            var transTime = new DateTime(2018, 11, 27);

            //act
            var book = new AccountBookHome(mock.Object);
            var bill = book.openBill(billName);

            var result = bill.AddTransaction(amount, transTime);

            //assert
            Assert.Equal(amount, result.TransactionAmount);
            Assert.Equal(transTime, result.TransactionTime);
        }
    }
}
