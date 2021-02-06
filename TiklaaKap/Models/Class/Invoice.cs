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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Tax { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxNumber { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        public decimal Total { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string adress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string phone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivering { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivery { get; set; }
        public ICollection<InvoiceData> InvoiceDatas { get; set; }

    }
}