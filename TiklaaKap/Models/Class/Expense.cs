using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(130)]
        public string ExpenseDesc { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal ExpensePrice { get; set; }
    }
}