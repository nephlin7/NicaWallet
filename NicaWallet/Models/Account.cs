using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int AccountTypeId { get; set; }
        public double StartingAmount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? IsActive { get; set; }
    }
}