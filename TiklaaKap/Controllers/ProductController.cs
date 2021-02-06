using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var product = c.Products.Where(x => x.Information == true).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> prodlist = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.proList = prodlist;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {

            c.Products.Add(p);
            p.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var pro = c.Products.Find(id);
            pro.Information = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ProductActive(int id)
        {
            var pro = c.Products.Find(id);
            pro.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifProduct()
        {
            var pasifproduct = c.Products.Where(x => x.Information == false).ToList();
            return View(pasifproduct);
        }
        public ActionResult ProductView(int id)
        {
            List<SelectListItem> prodlist = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.proList = prodlist;
            var product = c.Products.Find(id);
            return View("ProductView", product);
        }
        public ActionResult ProductUpdate(Product prd)
        {
            var pro = c.Products.Find(prd.ProductID);
            pro.ProductName = prd.ProductName;
            pro.Information = prd.Information;
            pro.ProductImage = prd.ProductImage;
            pro.BuyPrice = prd.BuyPrice;
            pro.SellPrice = prd.SellPrice;
            pro.Stock = prd.Stock;
            pro.ProductBrand = prd.ProductBrand;
            pro.ProductDesc = prd.ProductDesc;
            pro.CategoryID = prd.CategoryID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ProductList()
        {
            var list = c.Products.ToList();
            return View(list);
        }
    }
}