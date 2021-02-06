using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class CategoryController : Controller
    {


        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var category = c.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category cat)
        {
            c.Categories.Add(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryView(int id)
        {
            var category = c.Categories.Find(id);
            return View("CategoryView", category);
        }
        public ActionResult CategoryUpdate(Category cat)
        {
            var category = c.Categories.Find(cat.CategoryID);
            category.CategoryName = cat.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}