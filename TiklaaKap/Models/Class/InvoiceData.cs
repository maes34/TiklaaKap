using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class InvoiceData
    {
        [Key]
        public int InvoiceDataid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public Invoice Invoices { get; set; }
    }
}