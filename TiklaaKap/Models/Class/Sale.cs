using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class Sale
    {
        [Key]
        public int SalesID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductID { get; set; }
        public int CariID { get; set; }
        public int StaffID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Staff Staff { get; set; }
    }
}