using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Sales.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            List<SelectListItem> prodlist = (from x in c.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.ProductID.ToString(),
                                                 Text = x.ProductName
                                             }).ToList();
            List<SelectListItem> carilist = (from x in c.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.CariID.ToString()
                                             }).ToList();
            List<SelectListItem> stafflist = (from x in c.Staffs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.StaffName + " " + x.StaffSurname,
                                                  Value = x.StaffID.ToString()
                                              }).ToList();
            ViewBag.carilist = carilist;
            ViewBag.productlist = prodlist;
            ViewBag.stafflist = stafflist;
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(Sale s)
        {
            c.Sales.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesView(int id)
        {
            List<SelectListItem> prodlist = (from x in c.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.ProductID.ToString(),
                                                 Text = x.ProductName
                                             }).ToList();
            List<SelectListItem> carilist = (from x in c.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.CariID.ToString()
                                             }).ToList();
            List<SelectListItem> stafflist = (from x in c.Staffs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.StaffName + " " + x.StaffSurname,
                                                  Value = x.StaffID.ToString()
                                              }).ToList();
            ViewBag.carilist = carilist;
            ViewBag.productlist = prodlist;
            ViewBag.stafflist = stafflist;
            var sale = c.Sales.Find(id);
            return View("SalesView", sale);
        }
        public ActionResult SalesUpdate(Sale p)
        {
            var sale = c.Sales.Find(p.SalesID);
            sale.CariID = p.CariID;
            sale.StaffID = p.StaffID;
            sale.Quantity = p.Quantity;
            sale.Price = p.Price;
            sale.Date = p.Date;
            sale.TotalPrice = p.TotalPrice;
            sale.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var list = c.Sales.Where(x => x.SalesID == id).ToList();
            return View(list);
        }
    }
}