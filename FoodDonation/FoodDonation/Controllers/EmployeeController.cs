using FoodDonation.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDonation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee e)
        {
            MIDEntities1 nGOEntities = new MIDEntities1();
            var login = (from c in nGOEntities.Employees
                         where c.Name == e.Name && c.Password == e.Password
                         select c);
            if (login != null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            MIDEntities1 nGOEntities = new MIDEntities1();
            nGOEntities.Employees.Add(e);
            nGOEntities.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult List()
        {
            var db = new MIDEntities1();
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult Edit(int id)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Employees
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Employees
                       where it.id == e.id
                       select it).SingleOrDefault();
            ext.Name = e.Name;
            ext.Email = e.Email;
            ext.Contact = e.Contact;
            ext.Password = e.Password;


            db.SaveChanges();
            return RedirectToAction("List", "Employee");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Employees
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Employee e)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Employees
                       where it.id == e.id
                       select it).SingleOrDefault();
            db.Employees.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("List", "Employee");
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Employee e)
        {

            MIDEntities1 nGOEntities = new MIDEntities1();

            nGOEntities.Employees.Add(e);
            nGOEntities.SaveChanges();
            return RedirectToAction("Login", "Employee");
            //return View(u);
        }
        public ActionResult Order()
        {
            var db = new MIDEntities1();
            var foods = db.Foods.ToList();
            return View(foods);
        }
        public ActionResult OrderEdit(int id)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult OrderEdit(Food e)
        {
            var db = new MIDEntities1();
            var ext = (from it in db.Foods
                       where it.id == e.id
                       select it).SingleOrDefault();
            ext.Name = e.Name;
            ext.ExpireDate = e.ExpireDate;
            ext.State = e.State;
            ext.Resturant = e.Resturant;
            ext.Location = e.Location;
            ext.Receiver = e.Receiver;
            db.SaveChanges();
            return RedirectToAction("Order", "Employee");
        }
    }
}