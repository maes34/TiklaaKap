using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class ProductDetail
    {
        public IEnumerable<Product> value1 { get; set; }
        public IEnumerable<Detail> value2 { get; set; }
    }
}