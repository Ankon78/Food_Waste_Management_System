using FoodDonation.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDonation.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Food f)
        {
            MIDEntities1 mIDEntities1 = new MIDEntities1();
            mIDEntities1.Foods.Add(f);
            mIDEntities1.SaveChanges();
            return RedirectToAction("Index", "Resturant");
        }
        public ActionResult List()
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
            ext.Name = f.Name;
            ext.ExpireDate = f.ExpireDate;
            //ext.State = f.State;
            ext.Resturant = f.Resturant;
            ext.Location = f.Location;
            //ext.Receiver = f.Receiver;


            db.SaveChanges();
            return RedirectToAction("List", "Resturant");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Food s)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == s.id
                       select it).SingleOrDefault();
            db.Foods.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("List", "Resturant");
        }
        public ActionResult Status()
        {
            var db = new MIDEntities1();
            var foods = db.Foods.ToList();
            return View(foods);
        }
    }
}