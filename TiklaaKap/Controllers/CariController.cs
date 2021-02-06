using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var cari = c.Carilers.Where(x => x.Information == true).ToList();
            return View(cari);
        }
        [HttpGet]
        public ActionResult CariAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariAdd(Cariler cs)
        {
            c.Carilers.Add(cs);
            cs.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariDelete(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Information = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariActive(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifCari()
        {
            var cari = c.Carilers.Where(x => x.Information == false).ToList();
            return View(cari);
        }
        public ActionResult CariView(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariView", cari);
        }
        public ActionResult CariUpdate(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("CariView");
            }
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSehir = cr.CariSehir;
            cari.CariMail = cr.CariMail;
            cari.Information = cr.Information;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int id)
        {
            var sales = c.Sales.Where(x => x.CariID == id).ToList();
            var cariname = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.carname = cariname;
            return View(sales);
        }
    }
}