using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiklaaKap.Models.Class;

namespace TiklaaKap.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var stafflist = c.Staffs.Where(x => x.Information == true).ToList();
            return View(stafflist);
        }
        public ActionResult PasifStaff()
        {
            var pstafflist = c.Staffs.Where(x => x.Information == false).ToList();
            return View(pstafflist);
        }
        public ActionResult StaffDelete(int id)
        {
            var staff = c.Staffs.Find(id);
            staff.Information = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffActive(int id)
        {
            var astaff = c.Staffs.Find(id);
            astaff.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffView(int id)
        {
            List<SelectListItem> departlist = (from x in c.Departments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString()
                                               }).ToList();
            ViewBag.depList = departlist;
            var stf = c.Staffs.Find(id);
            return View("StaffView", stf);
        }
        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffAdd(Staff stf)
        {

            var staf = c.Staffs.Add(stf);
            staf.Information = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffUpdate(Staff stf)
        {
            var staff = c.Staffs.Find(stf.StaffID);
            staff.StaffName = stf.StaffName;
            staff.StaffSurname = stf.StaffSurname;
            staff.StaffImage = stf.StaffImage;
            staff.DepartmentID = stf.DepartmentID;
            staff.Information = stf.Information;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}