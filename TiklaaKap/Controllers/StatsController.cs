using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        Context c = new Context();
        public ActionResult Index()
        {
            // 1
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            // 2
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            // 3
            var deger3 = c.Staffs.Count().ToString();
            ViewBag.d3 = deger3;
            // 4
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            // 5
            var deger5 = c.Products.Sum(x=> x.Stock).ToString();
            ViewBag.d5 = deger5;
            // 6
            var deger6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            // 7
            var deger7 = c.Products.Count(x => x.Stock <=20).ToString();
            ViewBag.d7 = deger7;
            // 8
            var deger8 = (from x in c.Products orderby x.SellPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            // 9
            var deger9 = (from x in c.Products orderby x.SellPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            // 10
            var deger10 = c.Products.Count(x => x.Category.CategoryName == "Beyaz Eşya").ToString();
            ViewBag.d10 = deger10;
            // 11
            var deger11 = c.Products.Count(x => x.Category.CategoryName == "Bilgisayar").ToString();
            ViewBag.d11 = deger11;
            // 12
            var deger12 = c.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            // 13
            var deger13 = c.Sales.GroupBy(x => x.Product.ProductName).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d13 = deger13;
            // 14
            var deger14 = c.Sales.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = deger14;
            // 15
            DateTime bugun = DateTime.Today;
            var deger15 = c.Sales.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = deger15;
            // 16
            //var deger16 = c.Sales.Where(x => x.Date == bugun).DefaultIfEmpty().Sum(y => y.TotalPrice).ToString();
            //ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult EasyTables()
        {
            var value = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Total = g.Count()
                        };
            return View(value.ToList());
        }
        public PartialViewResult Partial1()
        {
            var value2 = from x in c.Staffs
                         group x by x.DepartmentID into g
                         select new GroupClass2
                         {
                             DepartmentId = g.Key,
                             Total = g.Count()
                         };
            return PartialView(value2.ToList());
        }
    }
}