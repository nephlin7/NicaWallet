using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    [Table("Record")]
    public class Record
    {
        public int RecordId { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public bool? PaymentType { get; set; }
        public DateTime RecordDateInsert { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Account")]
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        #endregion
    }
}