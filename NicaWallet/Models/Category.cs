using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public bool? IsParent { get; set; }
    }
}