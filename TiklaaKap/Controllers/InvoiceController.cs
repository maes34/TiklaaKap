using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InvoiceAdd(Invoice p)
        {
            c.Invoices.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceView(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("InvoiceView", invoice);
        }
        public ActionResult InvoiceUpdate(Invoice f)
        {
            var invoices = c.Invoices.Find(f.InvoiceID);
            invoices.InvoiceSerino = f.InvoiceSerino;
            invoices.InvoiceNumber = f.InvoiceNumber;
            invoices.InvoiceDate = f.InvoiceDate;
            invoices.Delivering = f.Delivering;
            invoices.Delivery = f.Delivery;
            invoices.Tax = f.Tax;
            invoices.TaxNumber = f.TaxNumber;
            invoices.phone = f.phone;
            invoices.Time = f.Time;
            invoices.adress = f.adress;
            c.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult InvoiceDetail(int id)
        {
            var invoices = c.InvoiceDatas.Where(x => x.InvoiceID == id).ToList();
            var invoiceData = c.Invoices.Where(x => x.InvoiceID == id).Select(y => y.InvoiceNumber).FirstOrDefault();
            ViewBag.invoiceDatas = invoiceData;
            return View(invoices);
        }
        [HttpGet]
        public ActionResult InvoiceData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceData(InvoiceData d)
        {
            c.InvoiceDatas.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}