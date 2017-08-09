using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string Note { get; set; }
        public bool? PaymentType { get; set; }
    }
}