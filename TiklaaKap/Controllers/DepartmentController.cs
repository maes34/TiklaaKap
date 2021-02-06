using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Departments.Where(x => x.Information == true).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            c.Departments.Add(d);
            d.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Information = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifDepartment()
        {
            var plist = c.Departments.Where(x => x.Information == false).ToList();
            return View(plist);
        }
        public ActionResult DepartmentActive(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentView(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmentView", dpt);
        }
        public ActionResult DepartmentUpdate(Department dep)
        {
            var dept = c.Departments.Find(dep.DepartmentID);
            dept.DepartmentName = dep.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var dept = c.Staffs.Where(x => x.DepartmentID == id).ToList();
            var deptname = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.deptname = deptname;
            return View(dept);
        }
        public ActionResult DepartmentStaffSale(int id)
        {
            var sales = c.Sales.Where(x => x.StaffID == id).ToList();
            var staff = c.Staffs.Where(x => x.StaffID == id).Select(y => y.StaffName + " " + y.StaffSurname).FirstOrDefault();
            ViewBag.staffs = staff;
            return View(sales);
        }
    }
}