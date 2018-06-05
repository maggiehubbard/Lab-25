using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterSubmit(User user) //This action has no view, it only calls from the DAO to add user to DB
        {
            try
            {                
                DAOClass.RegisterUser(user); //calls the register user method from the DAO class
                return View("Dashboard"); 
            }
            catch (Exception e) //catches any exception, return readable error messae
            {                
                ViewBag.Message = $"Error: {e.Message} occured. Please try creating an account later";
            }

            ViewBag.Name = user.FirstName + user.LastName;
            ViewBag.Email = user.Email;
            ViewBag.Age = user.Age;
            ViewBag.Phone = user.Phone;

            return View ("Dashboard");
        }
    }
}