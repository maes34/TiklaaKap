using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class ProductDetailController : Controller
    {

        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.value1 = c.Products.Where(x=> x.ProductID == 1).ToList();
            productDetail.value2 = c.Details.Where(y => y.DetailID == 1).ToList();
            var product = c.Products.Where(x => x.ProductID == 1).ToList();
            return View(productDetail);
        }
    }
}