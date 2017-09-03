using System;
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

        [Required]
        [Display(Name ="Name")]
        public string AccountName { get; set; }        
        [Required]
        public double Amount { get; set; }
<<<<<<< HEAD
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdate { get; set; }        
        public bool IsActive { get; set; }        
=======
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? LastUpdate { get; set; }
        public bool? IsActive { get; set; }
>>>>>>> 930095f7e86138c917c05e8e53dc462c24b3d273
        public string UserId { get; set; }
        [Required]
        public string Color { get; set; }
<<<<<<< HEAD
        public string AccountIcon { get; set; }
=======

        #region FOREINGKEYS
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }
>>>>>>> 930095f7e86138c917c05e8e53dc462c24b3d273


        #region FOREINGKEYS        
        public int? CurrencyId { get; set; }
        
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [Display(Name = "Account Type")]
        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }


        //public virtual ApplicationUser User { get; set; }

        #endregion
    }
}