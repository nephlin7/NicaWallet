﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NicaWallet.Models
{
    [Table("Account")]
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public double StartingAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? IsActive { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [Display(Name = "Account Type")]
        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }

        
        public virtual ApplicationUser User { get; set; }

        #endregion
    }
}