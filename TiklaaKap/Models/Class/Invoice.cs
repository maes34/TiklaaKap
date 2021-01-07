using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string InvoiceSerino { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxNumber { get; set; }
        public DateTime Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivering { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivery { get; set; }
        public ICollection<InvoiceData> InvoiceDatas { get; set; }

    }
}