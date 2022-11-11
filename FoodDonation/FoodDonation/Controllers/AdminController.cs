using FoodDonation.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDonation.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var db = new MIDEntities1();
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult FoodList()
        {
            var db = new MIDEntities1();
            var foods = db.Foods.ToList();
            return View(foods);
        }
        public ActionResult Edit(int id)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Food f)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == f.id
                       select it).SingleOrDefault();
            /*ext.Name = f.Name;
            ext.ExpireDate = f.ExpireDate;
            
            ext.Resturant = f.Resturant;
            ext.Location = f.Location;*/
            ext.State = f.State;
            ext.Receiver = f.Receiver;


            db.SaveChanges();
            return RedirectToAction("FoodList", "Admin");
        }
    }
}