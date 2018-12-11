using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountBook.Models
{
    public class Transaction
    {
        [Required]
        public DateTime TransactionTime { get; set; }        
        public DateTime BillingTime { get; set; }

        [Required]
        public Currency TransactionCurrency { get; set; } = Currency.CAD;
        public Currency BillingCurrency { get; set; } = Currency.CAD;

        [Required]
        public decimal TransactionAmount { get; set; }
        public decimal BillingAmount { get; set; }

        public string Description { get; set; }

    }
}
