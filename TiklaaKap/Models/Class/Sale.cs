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
        //Ürün
        //Cari
        //Personel
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public Product Product { get; set; }
        public Cariler Cariler { get; set; }
        public Staff Staff { get; set; }
    }
}