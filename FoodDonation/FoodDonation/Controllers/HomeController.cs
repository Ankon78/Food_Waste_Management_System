using FoodDonation.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodDonation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User r)
        {
            MIDEntities1 mIDEntities1 = new MIDEntities1();
            var login = (from c in mIDEntities1.Users
                         where c.Name == r.Name && c.Password == r.Password && c.Role == r.Role
                         select c);
            if (login != null && r.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
           
           else  if (login != null && r.Role == "ROwner")
            {
                return RedirectToAction("Index", "Resturant");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User u)
        {

            MIDEntities1 mIDEntities1 = new MIDEntities1();
            mIDEntities1.Users.Add(u);
            mIDEntities1.SaveChanges();
            return RedirectToAction("Login", "Home");
            //return View(u);
        }
    }
}